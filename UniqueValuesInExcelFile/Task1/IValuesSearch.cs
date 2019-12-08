namespace UniqueValuesInExcelFile
{
    using System;
    using System.Collections.Generic;

    public interface IValuesSearch
    {
        HashSet<string> GetUniqueValuesFromLists(Tuple<HashSet<string>, HashSet<string>> countrylists);
    }
}
