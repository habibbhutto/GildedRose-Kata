using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<InventoryItem> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = InventoryItem.ConvertItemsToInventoryItems(Items);
        }

        public void DailyUpdate()
        {
            UpdateQuality();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
            }
        }
    }
}
