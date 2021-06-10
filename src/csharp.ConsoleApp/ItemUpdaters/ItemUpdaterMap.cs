using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class ItemUpdaterMap
    {
        protected readonly Dictionary<string, IItemUpdater> ItemUpdaters;

        public ItemUpdaterMap()
        {
            ItemUpdaters = new Dictionary<string, IItemUpdater>();
            Add<AgedBrieUpdater>();
            Add<SulfurasUpdater>();
            Add<BackstagePassesUpdater>();
            Add<ConjuredUpdater>();
            Add<StandardUpdater>();
        }

        public virtual void Add<T>() where T : IItemUpdater, new()
        {
            T itemUpdater = new T();
            ItemUpdaters.Add(itemUpdater.RegexPattern, itemUpdater);
        }

        public virtual IItemUpdater GetInstance(Item item)
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
