using csharp.ConsoleApp.ItemUpdaters;
using System.Collections.Generic;

namespace csharp.ConsoleApp.Extensions
{
    public static class ItemUpdaterDictionaryExtension
    {
        public static void Add<T>(this Dictionary<string, ItemUpdater> itemUpdaters)
            where T : ItemUpdater, new()
        {
            T itemUpdater = new T();
            itemUpdaters.Add(itemUpdater.RegexPattern, itemUpdater);
        }
    }
}
