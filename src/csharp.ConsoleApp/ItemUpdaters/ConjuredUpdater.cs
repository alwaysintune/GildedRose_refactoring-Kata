using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class ConjuredUpdater : ItemUpdater
    {
        public ConjuredUpdater()
            : base(qualityChange: -2)
        {
            RegexPattern = @"Conjured.*";
        }

        public override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);

            item.Quality = Math.Max(0,
                item.Quality + QualityChange * (item.SellIn < 0 ? 2 : 1));
        }
    }
}
