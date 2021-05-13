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

                /*
                 * Has shared logic between other items - a place for abstraction
                 * Also, does not conform to requirements: when sell by date passes,
                 * increases in Quality twice as fast
                 */
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }

                    item.SellIn -= 1;

                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    continue;
                }

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }
                    }

                    item.SellIn -= 1;

                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }

                    continue;
                }


                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }

                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }
                }
            }
        }
    }
}
