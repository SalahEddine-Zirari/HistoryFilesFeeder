using HistoryFilesFeeder.Epex;
using HistoryFilesFeeder;
using Microsoft.EntityFrameworkCore;
using HistoryFilesFeeder.Ef;

var filePaths = Directory.GetFiles(@"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\austria\Intraday Continuous\EOD\Historical\Results", "*.csv");

Extractor extract = new Extractor();


var result = extract.ExtractorMethod<IntradayContinuous>(filePaths);
using (var context = new DataHistoryDbContext())
{
    result.ToList().ForEach(e =>
    {
        try { context.Add(e); }
        catch (Exception ex) { };
    });

    context.SaveChanges();
}

