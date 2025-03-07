using CsvHelper;
using CsvReaderApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CsvReaderApp.Services
{
    public class CsvReaderService
    {
        public PersonDataset ReadCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>().ToList();
                return new PersonDataset { Personer = records };
            }
        }
    }
}