using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class ConjuredUpdater : ItemUpdaterBase, IItemUpdater
    {
        public ConjuredUpdater()
            : base(qualityChange: -2, regexPattern: @"Conjured.*")
        {
        }

        public void UpdateQuality(Item item)
        {
            UpdateSellIn(item);

            item.Quality = Math.Max(0,
                item.Quality + QualityChange * (item.SellIn < 0 ? 2 : 1));
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
