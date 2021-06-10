namespace csharp.ConsoleApp.ItemUpdaters
{
    public interface IItemUpdater
    {
        void UpdateQuality(Item item);

        void UpdateSellIn(Item item);

        string RegexPattern { get; }
    }
}
