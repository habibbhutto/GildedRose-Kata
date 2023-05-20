using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    public class BackstagePassesPolicy : Policy
    {
        public static string ID { get => PolicyNames.BACKSTAGE_PASSES; }
        public void Execute(InventoryItem item)
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
    }
}
