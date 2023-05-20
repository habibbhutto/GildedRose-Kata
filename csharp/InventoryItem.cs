using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class InventoryItem
    {
        private Item item;

        public string Name { get => item.Name; }
        public int Quality { get => item.Quality; }
        public int Expiry { get => item.SellIn; }

        public InventoryItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            switch (item.Name)
            {
                case SpecialCases.AGED_BRIE:
                    UpdateAgedBrie();
                    break;
                case SpecialCases.BACKSTAGE_PASSES:
                    UpdateBackstagePasses();
                    break;
                case SpecialCases.SULFURAS:
                    // Nothing to be done for Sulfuras
                    break;
                default:
                    UpdateStandardItem();
                    break;
            }
        }

        private void UpdateStandardItem()
        {
            DecreaseQuality();
            UpdateExpiry();

            if (IsExpired())
            {
                DecreaseQuality();
            }
        }

        private void UpdateBackstagePasses()
        {
            IncreaseQuality();

            if (Expiry < 11)
            {
                IncreaseQuality();
            }

            if (Expiry < 6)
            {
                IncreaseQuality();
            }

            UpdateExpiry();

            if (IsExpired())
            {
                DropQualityToZero();
            }
        }

        private void UpdateAgedBrie()
        {
            IncreaseQuality();
            UpdateExpiry();

            if (IsExpired())
            {
                IncreaseQuality();
            }
        }

        private void IncreaseQuality()
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private void DropQualityToZero()
        {
            item.Quality = 0;
        }

        private void UpdateExpiry()
        {
            item.SellIn--;
        }

        public bool IsExpired()
        {
            return item.SellIn < 0;
        }

        public static IList<InventoryItem> ConvertItemsToInventoryItems(IList<Item> items)
        {
            IList<InventoryItem> inventoryItems = new List<InventoryItem>();
            foreach (var item in items)
            {
                inventoryItems.Add(new InventoryItem(item));
            }

            return inventoryItems;
        }
    }
}
