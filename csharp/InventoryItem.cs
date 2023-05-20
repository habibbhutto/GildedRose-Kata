using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Policies;

namespace csharp
{
    public class InventoryItem
    {
        private Item item;

        public string Name { get => item.Name; }
        public int Quality { get => item.Quality; }
        public int Expiry { get => item.SellIn; }

        public InventoryItem(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// Updates quality of items based on implemented policies
        /// in the policies module
        /// </summary>
        public void UpdateQuality()
        {
            Policy policy = Policies.Policies.GetPolicy(item.Name);
            policy.Execute(this);
        }

        /// <summary>
        /// Increases quality by one
        /// </summary>
        public void IncreaseQuality()
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        /// <summary>
        /// Increases quality by given value
        /// </summary>
        /// <param name="value"></param>
        public void IncreaseQualityBy(int value)
        {
            if (item.Quality < 50)
            {
                item.Quality += value;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        /// <summary>
        /// Decreases quality by one
        /// </summary>
        public void DecreaseQuality()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        /// <summary>
        /// Decreases quality by given value
        /// </summary>
        /// <param name="value"></param>
        public void DecreaseQualityBy(int value)
        {
            if (item.Quality > 0)
            {
                item.Quality -= value;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        /// <summary>
        /// Sets quality of the item to zero
        /// </summary>
        public void DropQualityToZero()
        {
            item.Quality = 0;
        }

        /// <summary>
        /// Updates expiry, decreasing it by one
        /// </summary>
        public void UpdateExpiry()
        {
            item.SellIn--;
        }

        /// <summary>
        /// returns true if the item has been expired
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return item.SellIn < 0;
        }

        /// <summary>
        /// Converts item data contract to InventoryItem entity
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
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
