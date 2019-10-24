using System;

namespace Serialization
{
    [Serializable]
    public class Car
    {
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public double Price { get; set; }
        public string CountryOfCarProducing { get; set; }


    }
}
