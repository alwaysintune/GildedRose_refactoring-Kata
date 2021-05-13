namespace csharp.ConsoleApp.ItemUpdaters
{
    public class SulfurasUpdater : ItemUpdater
    {
        public SulfurasUpdater() : base(qualityChange: 0)
        {
            RegexPattern = "Sulfuras.*";
        }

        public override void UpdateQuality(Item item)
        {
            if (item.Quality != 80)
                item.Quality = 80;
        }
    }
}
