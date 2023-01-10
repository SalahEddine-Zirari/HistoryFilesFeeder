using HistoryFilesFeeder.Epex;
using SharpCompress.Common;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using HistoryFilesFeeder;
using System;

var filePaths = Directory.GetFiles(@"C:\Users\ODIN\Desktop\Lanatech\histo-students\epex\austria\Intraday Continuous\EOD\Historical\Results", "*.csv");


using (Extractor extract = new Extractor())
{

    var result = extract.ExtractorMethod<IntradayContinuous>(filePaths);
};