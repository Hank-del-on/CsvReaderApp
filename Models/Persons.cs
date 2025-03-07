namespace CsvReaderApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Alder { get; set; }
    }

    public class PersonDataset
    {
        public List<Person> Personer { get; set; } = new List<Person>();
    }
}