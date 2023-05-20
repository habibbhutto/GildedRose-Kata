using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    public class AgedBriePolicy : Policy
    {
        public static string ID { get => SpecialCases.AGED_BRIE; }
        public void Execute(InventoryItem item)
        {
            item.IncreaseQuality();
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.IncreaseQuality();
            }
        }
    }
}
