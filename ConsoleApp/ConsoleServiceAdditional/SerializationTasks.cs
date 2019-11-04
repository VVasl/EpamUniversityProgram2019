namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using Serialization;
    using Common;

    public class SerializationTasks : Tasks
    {
        private IEnumerable<Car> car = new List<Car>{
                new Car{ BrandName = "Mercedes", ModelYear = 2016, Price = 40000, CountryOfCarProducing = "Germany" },
                new Car{ BrandName = "Toyota", ModelYear = 2012, Price = 10000, CountryOfCarProducing = "Japan" }
            };
        public void RunBinary()
        {
            try
            {
                this.writer.Write("\n\n-----Serialization. Task BinarySerializatiobOfCarCollection.");
                BinarySerializationOfCarCollection<Car> binary = new BinarySerializationOfCarCollection<Car>(this.configuration["binaryFile"]);

                this.writer.Write("\nCollection of Car objects is serialized to file using Binary Serializer.");
                binary.Serialize(car);
                IEnumerable<Car> deserializeCar = binary.Deserialize();

                this.writer.Write("Data from the Binary file.");
                WriteCars(deserializeCar);
            }
            
            catch (ArgumentException e)
            {
                this.writer.Write(e.Message);
            }
        }

        public void RunJson()
        {
            try
            {
                this.writer.Write("\n\n-----Serialization. Task JSONSerializatiobOfCarCollection.");
                JsonSerializationOfCarCollection<Car> json = new JsonSerializationOfCarCollection<Car>(this.configuration["jsonFile"]);

                this.writer.Write("\nCollection of Car objects is serialized to file using JSON Serializer.");
                json.Serialize(car);
                IEnumerable<Car> deserializeCar = json.Deserialize();

                this.writer.Write("Data from the JSON file.");
                WriteCars(deserializeCar);
            }

            catch (ArgumentException e)
            {
                this.writer.Write(e.Message);
            }
        }

        public void RunXml()
        {
            this.writer.Write("\n\n-----Serialization. Task XMLSerializatiobOfCarCollection.");
            try
            {
                XmlSerializationOfCarCollection<Car> xml = new XmlSerializationOfCarCollection<Car>(this.configuration["xmlFile"]);

                this.writer.Write("\nCollection of Car objects is serialized to file using XML Serializer.");
                xml.Serialize(car);
                IEnumerable<Car> deserializeCar = xml.Deserialize();

                this.writer.Write("Data from the Binary file.");
                WriteCars(deserializeCar);
            }

            catch(ArgumentException e)
            {
                this.writer.Write(e.Message);
            }  
        }

        private void WriteCars(IEnumerable<Car> deserializeCar)
        {
            ParameterValidation.AssertNotNullOrEmpty(deserializeCar, nameof(deserializeCar));

            foreach (var item in deserializeCar)
            {
                this.writer.Write($"\t{item.BrandName} {item.ModelYear} {item.Price} {item.CountryOfCarProducing}");
            }
        }
    }
}
