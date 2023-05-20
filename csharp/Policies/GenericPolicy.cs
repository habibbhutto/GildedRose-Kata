using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    class GenericPolicy : Policy
    {
        public static string ID { get => SpecialCases.DEFAULT; }
        public void Execute(InventoryItem item)
        {
            item.DecreaseQuality();
            item.UpdateExpiry();

            if (item.IsExpired())
            {
                item.DecreaseQuality();
            }
        }
    }
}
