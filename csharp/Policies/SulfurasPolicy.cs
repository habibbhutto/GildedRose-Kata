using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    public class SulfurasPolicy : Policy
    {
        public static string ID { get => SpecialCases.SULFURAS; }

        public void Execute(InventoryItem item)
        {
            // Sulfuras stay the same
        }
    }
}
