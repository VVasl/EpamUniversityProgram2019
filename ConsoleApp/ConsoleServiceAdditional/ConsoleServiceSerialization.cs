using System;
using System.Collections.Generic;
using Serialization;
using Common;



namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private IEnumerable<Car> car = new List<Car>{
                new Car{ BrandName = "Mercedes", ModelYear = 2016, Price = 40000, CountryOfCarProducing = "Germany" },
                new Car{ BrandName = "Mercedes", ModelYear = 2016, Price = 40000, CountryOfCarProducing = "Germany" }
            };
        private void RunBinary()
        {
            BinarySerializationOfCarCollection <Car>  binary = new BinarySerializationOfCarCollection<Car>("DataFileofCars.dat");

            Console.WriteLine("\nCollection of Car objects is serialized to file using Binary Serializer.");
            binary.Serialize(car);
            IEnumerable<Car> deserializecar = binary.Deserialize();

            Console.WriteLine("Data from the Binary file.");
            foreach(var item in deserializecar)
            {
                Console.WriteLine($"\t{item.BrandName} {item.ModelYear} {item.Price} {item.CountryOfCarProducing}");
            }
        }

        private void RunJson()
        {
            JsonSerializationOfCarCollection<Car> json = new JsonSerializationOfCarCollection<Car>("DataFileofCars.json");

            Console.WriteLine("\nCollection of Car objects is serialized to file using JSON Serializer.");
            json.Serialize(car);
            IEnumerable<Car> deserializecar = json.Deserialize();

            Console.WriteLine("Data from the JSON file.");
            foreach (var item in deserializecar)
            {
                Console.WriteLine($"\t{item.BrandName} {item.ModelYear} {item.Price} {item.CountryOfCarProducing}");
            }
        }

        private void RunXml()
        {
            XmlSerializationOfCarCollection<Car> xml = new XmlSerializationOfCarCollection<Car>("DataFileofCars.xml");

            Console.WriteLine("\nCollection of Car objects is serialized to file using XML Serializer.");
            xml.Serialize(car);
            IEnumerable<Car> deserializecar = xml.Deserialize();

            Console.WriteLine("Data from the Binary file.");
            foreach (var item in deserializecar)
            {
                Console.WriteLine($"\t{item.BrandName} {item.ModelYear} {item.Price} {item.CountryOfCarProducing}");
            }
        }


    }
}
