﻿using CsvHelper;
using System.Globalization;


namespace HistoryFilesFeeder;

public class Extractor : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> ExtractorMethod<T>(string[] filePaths)
    {
        List<T> objects = new List<T>();

        foreach (var filePath in filePaths)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Configuration. = true;
                var records = (csvReader.GetRecords<T>().ToList());
                objects.AddRange(records);

            }
        }

        return objects;

    }
}

