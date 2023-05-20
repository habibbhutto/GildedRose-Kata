using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test(Description = "Once selldate has passed quality decreases twice as fast")]
        public void Once_SellDate_Has_Passed_Quality_Decreases_Twice_As_Fast()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Some standard item", SellIn = 0, Quality = 4 }
            };

            GildedRose app = new GildedRose(Items);
            app.DailyUpdate();

            Assert.AreEqual("Some standard item", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test(Description = "The quality of an item is never negative")]
        public void The_Quality_Of_An_Item_Is_Never_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Some standard item", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Some standard item", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);

            app.DailyUpdate();
            Assert.AreEqual("Some standard item", Items[0].Name);
            Assert.AreEqual(-3, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test(Description = "Aged Brie increases in quality")]
        public void Aged_Brie_Increases_In_Quality_As_Days_Pass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void Aged_Brie_Increases_In_Quality_To_Max_50_After_SellIn_Days_Has_Passed()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Aged Brie", SellIn = -1, Quality = 49 } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test(Description = "The quality of an item is never more than 50")]
        public void The_Quality_Of_An_Item_Is_Never_More_Than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test(Description = "Sulfuras never has to be sold neither decrease in quality, always remains 80")]
        public void Sulfuras_Never_Has_To_Be_Sold_Neither_Decreases_In_Quality()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 3,
                Quality = 80
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(3, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test(Description = "Backstage passes increase in quality as days pass")]
        public void Backstage_Passes_Increase_In_Quality_As_Days_Pass()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(14, Items[0].SellIn);
            Assert.AreEqual(21, Items[0].Quality);
        }

        [Test(Description = "Backstae passes increase in quality by 2 when 10 days or less")]
        public void Backstage_Passes_Increase_In_Quality_By_2_When_10_Days_Or_Less()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(22, Items[0].Quality);
        }

        [Test(Description = "Backstage passes increase in quality by 3 when 5 days or less")]
        public void Backstage_Passes_Increase_In_Quality_By_3_When_5_Days_Or_Less()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(23, Items[0].Quality);
        }

        [Test(Description = "Backstage passes quality drops to 0 after concert")]
        public void Backstage_Passes_Quality_Drops_To_0_After_Concert()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 10
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test(Description = "Any new item not in special cases treated as standard item")]
        public void Any_New_Item_Not_In_Special_Cases_Treated_As_Standard_Item()
        {
            IList<Item> Items = new List<Item> { new Item {
                Name = "A new item contracted",
                SellIn = 1,
                Quality = 8
            } };
            GildedRose app = new GildedRose(Items);

            app.DailyUpdate();
            Assert.AreEqual("A new item contracted", Items[0].Name);
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(7, Items[0].Quality);

            app.DailyUpdate();
            Assert.AreEqual("A new item contracted", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(5, Items[0].Quality);
        }
    }
}
