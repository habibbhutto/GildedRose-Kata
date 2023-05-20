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
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].DecreaseQuality();
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].IncreaseQuality();

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Expiry < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].IncreaseQuality();
                                }
                            }

                            if (Items[i].Expiry < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].IncreaseQuality();
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].UpdateExpiry();
                }

                if (Items[i].IsExpired())
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].DecreaseQuality();
                                }
                            }
                        }
                        else
                        {
                            Items[i].DropQualityToZero();
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].IncreaseQuality();
                        }
                    }
                }
            }
        }
    }
}
