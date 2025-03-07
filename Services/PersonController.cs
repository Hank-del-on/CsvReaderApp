using Microsoft.AspNetCore.Mvc;
using CsvReaderApp.Models;
using CsvReaderApp.Services;
using System.Diagnostics;

namespace CsvReaderApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly CsvReaderService _csvReaderService;

        public PersonController()
        {
            _csvReaderService = new CsvReaderService();
            // Husk å angi riktig filbane til CSV-filen
            string filePath = "path/to/your/dataset.csv";
            Dataset = _csvReaderService.ReadCsv(filePath);
        }

        public PersonDataset Dataset { get; }

        public IActionResult Index()
        {
            return View(Dataset);
        }

        [HttpPost]
        public IActionResult Search(int id)
        {
            var person = Dataset.Personer.FirstOrDefault(p => p.Id == id);
            return View("Index", person != null ? new[] { person } : new Person[0]);
        }
    }
}