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

        private void UpdateItem(InventoryItem item)
        {
            switch (item.Name)
            {
                case SpecialCases.AGED_BRIE:
                    {
                        item.IncreaseQuality();
                        item.UpdateExpiry();

                        if (item.IsExpired())
                        {
                            item.IncreaseQuality();
                        }
                    }
                    break;
                case SpecialCases.BACKSTAGE_PASSES:
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
                    break;
                case SpecialCases.SULFURAS:
                    {
                        // Nothing to be done for Sulfuras
                    }
                    break;
                default:
                    {
                        item.DecreaseQuality();
                        item.UpdateExpiry();

                        if (item.IsExpired())
                        {
                            item.DecreaseQuality();
                        }
                    }
                    break;
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
                UpdateItem(Items[i]);
            }
        }
    }
}
