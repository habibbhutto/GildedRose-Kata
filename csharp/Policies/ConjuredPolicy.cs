using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    class ConjuredPolicy : Policy
    {
        public static string ID { get => SpecialCases.CONJURED; }
        public void Execute(InventoryItem item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.DecreaseQuality();
                item.DecreaseQuality();
            }
        }
    }
}
