using System.Collections.Generic;
using System.IO;
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

            using (FileStream fs = new FileStream(DataFileofCars, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                carCollection = (IEnumerable<T>)formatter.Deserialize(fs);
            }
            
            return carCollection;
        }
    }
}
