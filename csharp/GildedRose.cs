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

        private void UpdateItemQuality(InventoryItem item)
        {
            switch (item.Name)
            {
                case SpecialCases.AGED_BRIE:
                    UpdateAgedBrie(item);
                    break;
                case SpecialCases.BACKSTAGE_PASSES:
                    UpdateBackstagePasses(item);
                    break;
                case SpecialCases.SULFURAS:
                    // Nothing to be done for Sulfuras
                    break;
                default:
                    UpdateStandardItem(item);
                    break;
            }
        }

        private void UpdateStandardItem(InventoryItem item)
        {
            item.DecreaseQuality();
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.DecreaseQuality();
            }
        }

        private void UpdateBackstagePasses(InventoryItem item)
        {
            item.IncreaseQuality();

            if (item.Expiry < 11)
            {
                item.IncreaseQuality();
            }

            if (item.Expiry < 6)
            {
                item.IncreaseQuality();
            }

            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.DropQualityToZero();
            }
        }

        private void UpdateAgedBrie(InventoryItem item)
        {
            item.IncreaseQuality();
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.IncreaseQuality();
            }
        }

        public void DailyUpdate()
        {
            UpdateQuality();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemQuality(Items[i]);
            }
        }
    }
}
