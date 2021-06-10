using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class BackstagePassesUpdater : ItemUpdaterBase, IItemUpdater
    {
        public BackstagePassesUpdater()
            : base(qualityChange: 0, regexPattern: @"Backstage passes.*")
        {
        }

        public void UpdateQuality(Item item)
        {
            UpdateSellIn(item);

            if (item.SellIn >= 10)
                item.Quality += 1;
            else if (item.SellIn >= 5)
                item.Quality += 2;
            else if (item.SellIn >= 0)
                item.Quality += 3;
            else
                item.Quality = 0;

            item.Quality = Math.Min(50, item.Quality);
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
