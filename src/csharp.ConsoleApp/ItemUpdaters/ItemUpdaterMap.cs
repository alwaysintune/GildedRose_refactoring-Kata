using csharp.ConsoleApp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class ItemUpdaterMap
    {
        protected readonly Dictionary<string, ItemUpdater> ItemUpdaters;

        public ItemUpdaterMap()
        {
            ItemUpdaters = new Dictionary<string, ItemUpdater>();
            ItemUpdaters.Add<AgedBrieUpdater>();
            ItemUpdaters.Add<SulfurasUpdater>();
            ItemUpdaters.Add<BackstagePassesUpdater>();
            ItemUpdaters.Add<StandardUpdater>();
        }

        public virtual void Add<T>() where T : ItemUpdater, new()
        {
            ItemUpdaters.Add<T>();
        }

        public virtual ItemUpdater GetInstance(Item item)
        {
            var itemUpdater = ItemUpdaters
                .Select(x => x.Value)
                .Where(x => Regex.Match(item.Name, x.RegexPattern).Success)
                .FirstOrDefault();

            if (itemUpdater == null)
            {
                itemUpdater = ItemUpdaters[nameof(StandardUpdater)];
            }

            return itemUpdater;
        }
    }
}
