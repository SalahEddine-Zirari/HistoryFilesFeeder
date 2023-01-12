using HistoryFilesFeeder.Epex;
using HistoryFilesFeeder;
using Microsoft.EntityFrameworkCore;
using HistoryFilesFeeder.Ef;

var filePaths = Directory.GetFiles(@"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\switzerland\Intraday Continuous\EOD\Results", "*.csv");

Extractor extract = new Extractor();


var result = extract.ExtractorMethod<IntradayContinuous>(filePaths);
using (var context = new DataHistoryDbContext())
{
    context.AddRangeAsync(result);
    context.SaveChanges();
}



