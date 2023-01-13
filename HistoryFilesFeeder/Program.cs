using HistoryFilesFeeder.Epex;
using HistoryFilesFeeder;
using Microsoft.EntityFrameworkCore;
using HistoryFilesFeeder.Ef;
using SharpCompress.Readers;
using System.Drawing.Text;



Extractor extract = new Extractor();
string[] Areas = { "Austria", "France", "Germany", "Netherlands", "Poland", "Switzerland" };
string[] Concatenate(string area, string filepath)
{

    return filepath == "fp1" ?
        Directory.GetFiles(@"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\" + area + @"\Intraday Continuous\EOD\Results", "*.csv") :
        Directory.GetFiles(@"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\" + area + @"\Intraday Continuous\EOD\Historical\Results", "*.csv");
}

void Insert(string filepath)
{
    foreach (var area in Areas)
    {
        if (area == "Poland" && filepath.Contains("Historical")) { continue; }
        var resultFromPath = Concatenate(area.ToLower(), filepath);
        var result = extract.ExtractorMethod<IntradayContinuous>(resultFromPath); ;
        using (var context = new DataHistoryDbContext())
        {
            var removeDuplicates = result.GroupBy(x => new { x.Area, x.DeliveryStart, x.DeliveryEnd }).Select(x => x.First());

            context.AddRangeAsync(removeDuplicates);
            context.SaveChanges();
        }
    }
}

Insert("fp1");
Insert("fp2");




//C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\{ZONE}\Intraday Continuous\EOD\Results
//C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\{zone}\Intraday Continuous\EOD\Historical\Results




