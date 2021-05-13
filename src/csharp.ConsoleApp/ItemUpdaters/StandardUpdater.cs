using System;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class StandardUpdater : ItemUpdater
    {
        public StandardUpdater()
            : base(qualityChange: -1)
        {
            RegexPattern = nameof(StandardUpdater);
        }

        public override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);

            item.Quality = Math.Max(0,
                item.Quality + QualityChange * (item.SellIn < 0 ? 2 : 1));
        }
    }
}
