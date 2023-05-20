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

        public InventoryItem(Item item)
        {
            this.item = item;
        }

        public void increaseQuality()
        {
            item.Quality++;
        }

        public void decreaseQuality()
        {
            item.Quality--;
        }

        public void updateExpiry()
        {
            item.SellIn--;
        }

        public bool isExpired()
        {
            return item.SellIn < 0;
        }

        public static IList<InventoryItem> convertItemsToInventoryItems(IList<Item> items)
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
