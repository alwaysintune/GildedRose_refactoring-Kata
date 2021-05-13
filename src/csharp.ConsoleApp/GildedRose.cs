using System.Collections.Generic;

namespace csharp.ConsoleApp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                // Does not degrade, neither has SellIn value modified
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;

                item.SellIn -= 1;

                /*
                 * Has shared logic between other items - a place for abstraction
                 * Also, does not conform to requirements: when sell by date passes,
                 * increases in Quality twice as fast
                 */
                if (item.Name == "Aged Brie")
                {
                    item.Quality = System.Math.Min(50, item.Quality + 1 * (item.SellIn < 0 ? 2 : 1));

                    continue;
                }

                /* SellIn value only partially affects Backstage passes before being decreased
                 */
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn >= 10)
                    {
                        item.Quality += 1;
                    }
                    else if (item.SellIn >= 5)
                    {
                        item.Quality += 2;
                    }
                    else if (item.SellIn >= 0)
                    {
                        item.Quality += 3;
                    }
                    else
                    {
                        item.Quality = 0;
                    }

                    item.Quality = System.Math.Min(50, item.Quality);

                    continue;
                }


                // Shares common logic with "Aged Brie"; only difference in sign
                item.Quality = System.Math.Max(0, item.Quality - 1 * (item.SellIn < 0 ? 2 : 1));
            }
        }
    }
}
