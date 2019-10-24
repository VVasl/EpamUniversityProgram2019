using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Serialization
{
    public class JsonSerializationOfCarCollection<T> : ICollectionSerializable<T>
        where T : Car
    {
        public string DataFileofCars { get; set; }

        public JsonSerializationOfCarCollection(string dataFileofCars)
        {
            DataFileofCars = dataFileofCars;
        }

        public void Serialize(IEnumerable<T> carCollection)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(DataFileofCars))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, carCollection);
                }
            }

                
        }

        public IEnumerable<T> Deserialize()
        {
            IEnumerable<T> carCollection;
            try
            {
                carCollection = JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText(DataFileofCars));
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Unable to load Data.\nThe file \"" + DataFileofCars + "\" does not load correctly.", ex);
            }

            return carCollection;
        }
    }
}
