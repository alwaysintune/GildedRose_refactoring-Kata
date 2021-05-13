using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class AgedBrieUpdater : ItemUpdater
    {
        public AgedBrieUpdater()
            : base(qualityChange: 1)
        {
            RegexPattern = @"Aged Brie";
        }

        public override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);

            item.Quality = Math.Min(50,
                item.Quality + QualityChange * (item.SellIn < 0 ? 2 : 1));
        }
    }
}
