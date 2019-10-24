using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    public interface ICollectionSerializable<T>
        where T : class
    {
        void Serialize(IEnumerable<T> carCollection);
        IEnumerable<T> Deserialize();
    }
}
