using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Serialization
{
    public class XmlSerializationOfCarCollection<T> : ICollectionSerializable<T>
        where T : Car
    {
        public string DataFileofCars { get; set; }

        public XmlSerializationOfCarCollection(string dataFileofCars)
        {
                DataFileofCars = dataFileofCars;
        }
        public void Serialize(IEnumerable<T> carCollection)
        {
            if(carCollection is null)
                throw new System.ArgumentNullException(nameof(carCollection));

            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(carCollection.GetType());

                using (FileStream fs = new FileStream(DataFileofCars, FileMode.OpenOrCreate))
                {
                    xmlserializer.Serialize(fs, carCollection);
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            
        }

        public IEnumerable<T> Deserialize()
        {
           IEnumerable<T> carCollection; 
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer = new XmlSerializer(typeof(T[]));

            using (XmlReader reader = XmlReader.Create(new FileStream(DataFileofCars, FileMode.Open)))
            {
                carCollection = (IEnumerable<T>)serializer.Deserialize(reader);
            }
            
            return carCollection;
        }
    }
}
