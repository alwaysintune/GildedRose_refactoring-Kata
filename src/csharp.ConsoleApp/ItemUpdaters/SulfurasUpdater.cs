namespace csharp.ConsoleApp.ItemUpdaters
{
    public class SulfurasUpdater : ItemUpdaterBase, IItemUpdater
    {
        public SulfurasUpdater() 
            : base(qualityChange: 0, regexPattern: @"Sulfuras.*")
        {
        }

        public void UpdateQuality(Item item)
        {
            UpdateSellIn(item);

            if (item.Quality != 80)
                item.Quality = 80;
        }

        public void UpdateSellIn(Item item)
        {
            return;
        }
    }
}
