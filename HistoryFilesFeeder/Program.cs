using HistoryFilesFeeder.Epex;
using HistoryFilesFeeder;
using Microsoft.EntityFrameworkCore;
using HistoryFilesFeeder.Ef;
using SharpCompress.Readers;
using System.Drawing.Text;
using Azure.Core;

Extractor extract = new Extractor();
string[] Areas = { "Austria", "France", "Germany", "Netherlands", "Poland", "Switzerland" };
string Concatenate(string area, string filepath)
{
    return filepath == "fp1" ?
        @"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\" + area + @"\Intraday Continuous\EOD\Results" :
        @"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\" + area + @"\Intraday Continuous\EOD\Historical\Results";
}
List<IntradayContinuous> GetData(string filepath)
{
    var allData = new List<IntradayContinuous>();
    foreach (var area in Areas)
    {

        var resultFromPath = Concatenate(area.ToLower(), filepath);
        if (area == "Poland" && resultFromPath.Contains("Historical")) { continue; }
        var getData = Directory.GetFiles(resultFromPath, "*.csv");
        var result = extract.ExtractorMethod<IntradayContinuous>(getData, area);
        allData.AddRange(result);
    }
    return allData;
}

void InsertData(List<IntradayContinuous> fp1, List<IntradayContinuous> fp2)
{
    List<IntradayContinuous> allData = fp1;
    allData.AddRange(fp2);
    using (var context = new DataHistoryDbContext())
    {
        var removeDuplicates = allData.GroupBy(x => new { x.Area, x.DeliveryStart, x.DeliveryEnd }).Select(x => x.First());

        context.AddRangeAsync(removeDuplicates);
        context.SaveChanges();
    }
}

InsertData(GetData("fp1"), GetData("fp2"));









