using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CsvReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\kodeh\\Documents\\C #\\CSV data camera\\CsvReaderApp\\Cameradataset\\camera_dataset.csv"; // Replace with your actual CSV file path

            List<Camera> cameras = LoadCameras(filePath);

            Console.WriteLine("First 5 records:");
            foreach (var camera in cameras.Take(5))
            {
                Console.WriteLine($"ID: {camera.Id}, Model: {camera.Model}, Description: {camera.Description}");
            }

            Console.WriteLine("Would you like to save this data to a new CSV file? (yes/no)");
            var input = Console.ReadLine();

            if (input?.ToLower() == "yes")
            {
                SaveCamerasToCsv(cameras, "output_cameras.csv");
                Console.WriteLine("Data saved to output_cameras.csv");
            }
        }

        static List<Camera> LoadCameras(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Camera>().ToList();
            }
        }

        static void SaveCamerasToCsv(List<Camera> cameras, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(cameras);
            }
        }
    }
}