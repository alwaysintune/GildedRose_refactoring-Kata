namespace csharp.ConsoleApp.ItemUpdaters
{
    public abstract class ItemUpdater
    {
        protected int QualityChange { get; private set; }

        public string RegexPattern { get; protected set; }

        public ItemUpdater(int qualityChange)
        {
            QualityChange = qualityChange;
        }

        public virtual void UpdateQuality(Item item)
        {
            item.SellIn -= 1;
        }
    }
}
