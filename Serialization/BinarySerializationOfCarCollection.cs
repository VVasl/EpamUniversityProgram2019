using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class BinarySerializationOfCarCollection<T>: ICollectionSerializable<T>
        where T : Car
    {
        public string DataFileofCars { get; set; }

        public BinarySerializationOfCarCollection(string dataFileofCars)
        {
            DataFileofCars = dataFileofCars;
        }
        public void Serialize(IEnumerable<T> carCollection)
        {
             using(FileStream fs = new FileStream(DataFileofCars, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, carCollection);
            }
        }

        public IEnumerable<T> Deserialize()
        {
            IEnumerable<T> carCollection;

            // Open the file containing the data that you want to deserialize.
            using (FileStream fs = new FileStream(DataFileofCars, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the collection from the file and 
                // assign the reference to the local variable.
                carCollection = (IEnumerable<T>)formatter.Deserialize(fs);
            }
            

            return carCollection;
        }
    }
}
