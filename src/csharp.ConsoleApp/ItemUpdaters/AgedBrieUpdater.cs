using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class AgedBrieUpdater : ItemUpdaterBase, IItemUpdater
    {
        public AgedBrieUpdater()
            : base(qualityChange: 1, regexPattern: @"Aged Brie")
        {
        }

        public void UpdateQuality(Item item)
        {
            UpdateSellIn(item);

            item.Quality = Math.Min(50,
                item.Quality + QualityChange * (item.SellIn < 0 ? 2 : 1));
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
