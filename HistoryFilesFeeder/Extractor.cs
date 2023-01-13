using CsvHelper;
using HistoryFilesFeeder.Epex;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace HistoryFilesFeeder;

public class Extractor
{


    public IEnumerable<T> ExtractorMethod<T>(string[] filePaths, string area) where T : ILocatedObject
    {
        List<T> objects = new List<T>();

        foreach (var filePath in filePaths)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var firstLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var records = (csvReader.GetRecords<T>().ToList());
                    records.ForEach(x => x.Area = area);
                    objects.AddRange(records);
                }
            }
        }

        return objects;

    }
}

