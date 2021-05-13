using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.ConsoleApp.ItemUpdaters
{
    public class BackstagePassesUpdater : ItemUpdater
    {
        public BackstagePassesUpdater()
            : base(qualityChange: 0)
        {
            RegexPattern = @"Backstage passes.*";
        }

        public override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);

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
    }
}
