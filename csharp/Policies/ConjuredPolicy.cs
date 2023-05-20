using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    class ConjuredPolicy : Policy
    {
        public static string ID { get => PolicyNames.CONJURED; }
        public void Execute(InventoryItem item)
        {
            item.DecreaseQualityBy(2);
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.DecreaseQualityBy(2);
            }
        }
    }
}
