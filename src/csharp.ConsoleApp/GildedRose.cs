using csharp.ConsoleApp.ItemUpdaters;
using System.Collections.Generic;

namespace csharp.ConsoleApp
{
    public class GildedRose
    {
        IList<Item> Items;

        readonly ItemUpdaterMap _itemUpdaterMap;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            _itemUpdaterMap = new ItemUpdaterMap();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                _itemUpdaterMap.GetInstance(item).UpdateQuality(item);
            }
        }
    }
}
