using csharp.ConsoleApp;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.UnitTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Foo()
        {
            var item = ItemAfterOneDay("foo", sellIn: 0, quality: 0);
            Assert.AreEqual("foo", item.Name);
        }

        [Test]
        public void UpdateQuality_ShouldDecreaseSellInValue_WhenDayEnds()
        {
            var item = ItemAfterOneDay("_test", sellIn: 2, quality: 2);
            Assert.AreEqual(1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_ShouldDecreaseQualityValue_WhenDayEnds()
        {
            var item = ItemAfterOneDay("_test", sellIn: 2, quality: 2);
            Assert.AreEqual(1, item.Quality);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-1, ExpectedResult = 0)]
        public int UpdateQuality_ShouldDegradeQualityTwiceAsFast_WhenSellByDatePasses(int sellIn)
        {
            var item = ItemAfterOneDay("_test", sellIn, quality: 2);
            return item.Quality;
        }

        [Test]
        public void UpdateQuality_ShouldNotBeNegative_WhenQualityIsZero()
        {
            var item = ItemAfterOneDay("_test", sellIn: 2, quality: 0);
            Assert.AreEqual(0, item.Quality);
        }

        [TestCase(1, ExpectedResult = 3)]
        [TestCase(0, ExpectedResult = 4, Reason = "reverse of degradation when sell by date passes")]
        [TestCase(-1, ExpectedResult = 4, Reason = "reverse of degradation when sell by date passes")]
        public int UpdateQuality_ShouldIncreaseQuality_WhenAgedBrieSellInDecreases(int sellIn)
        {
            var item = ItemAfterOneDay("Aged Brie", sellIn, quality: 2);
            return item.Quality;
        }

        [TestCase("Aged Brie", 49, ExpectedResult = 50)]
        [TestCase("Aged Brie", 50, ExpectedResult = 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 49, ExpectedResult = 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 50, ExpectedResult = 50)]
        public int UpdateQuality_ShouldNotIncreaseQuality_WhenQualityLimitReached(string itemName, int quality)
        {
            var item = ItemAfterOneDay(itemName, sellIn: 2, quality);
            return item.Quality;
        }

        [Test(Description = "\"Sulfuras\" quality is always 80")]
        public void UpdateQuality_ShouldNotDecreaseQuality_WhenItemIsSulfuras()
        {
            var item = ItemAfterOneDay("Sulfuras, Hand of Ragnaros", sellIn: 2, quality: 80);
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByOne_WhenBackstagePassesSellInDateIsAboveTen()
        {
            var item = ItemAfterOneDay("Backstage passes to a TAFKAL80ETC concert", sellIn: 11, quality: 2);
            Assert.AreEqual(item.Quality, 3);
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByTwo_WhenBackstagePassesSellInDateIsAboveFive([Range(6, 10)] int sellIn)
        {
            var item = ItemAfterOneDay("Backstage passes to a TAFKAL80ETC concert", sellIn, quality: 2);
            Assert.AreEqual(item.Quality, 4);
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByThree_WhenBackstagePassesSellInDateIsAboveZero([Range(1, 5)] int sellIn)
        {
            var item = ItemAfterOneDay("Backstage passes to a TAFKAL80ETC concert", sellIn, quality: 2);
            Assert.AreEqual(item.Quality, 5);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-1, ExpectedResult = 0)]
        public int UpdateQuality_ShouldSetQualityToZero_WhenBackstagePassesSellByDatePasses(int sellIn)
        {
            var item = ItemAfterOneDay("Backstage passes to a TAFKAL80ETC concert", sellIn, quality: 6);
            return item.Quality;
        }

        private Item ItemAfterOneDay(string itemName, int sellIn, int quality)
        {
            IList<Item> items = new List<Item>
            {
                new Item
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();
            return items[0];
        }
    }
}
