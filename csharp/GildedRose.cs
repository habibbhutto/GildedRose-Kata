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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != SpecialCases.AGED_BRIE &&
                    Items[i].Name != SpecialCases.BACKSTAGE_PASSES)
                {
                    if (Items[i].Name != SpecialCases.SULFURAS)
                    {
                        Items[i].DecreaseQuality();
                    }
                }
                else
                {
                    Items[i].IncreaseQuality();

                    if (Items[i].Name == SpecialCases.BACKSTAGE_PASSES)
                    {
                        if (Items[i].Expiry < 11)
                        {
                            Items[i].IncreaseQuality();
                        }

                        if (Items[i].Expiry < 6)
                        {
                            Items[i].IncreaseQuality();
                        }
                    }
                }

                if (Items[i].Name != SpecialCases.SULFURAS)
                {
                    Items[i].UpdateExpiry();
                }

                if (Items[i].IsExpired())
                {
                    if (Items[i].Name != SpecialCases.AGED_BRIE)
                    {
                        if (Items[i].Name != SpecialCases.BACKSTAGE_PASSES)
                        {
                            if (Items[i].Name != SpecialCases.SULFURAS)
                            {
                                Items[i].DecreaseQuality();
                            }
                        }
                        else
                        {
                            Items[i].DropQualityToZero();
                        }
                    }
                    else
                    {
                        Items[i].IncreaseQuality();
                    }
                }
            }
        }
    }
}
