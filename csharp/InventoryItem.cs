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

        public void IncreaseQuality()
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public void DecreaseQuality()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        public void DropQualityToZero()
        {
            item.Quality = 0;
        }

        public void UpdateExpiry()
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
