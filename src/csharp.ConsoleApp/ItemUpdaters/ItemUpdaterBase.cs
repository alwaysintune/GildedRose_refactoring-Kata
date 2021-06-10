namespace csharp.ConsoleApp.ItemUpdaters
{
    public abstract class ItemUpdaterBase
    {
        public ItemUpdaterBase(int qualityChange, string regexPattern)
        {
            QualityChange = qualityChange;
            RegexPattern = regexPattern;
        }

        protected int QualityChange { get; private set; }

        public string RegexPattern { get; protected set; }
    }
}
