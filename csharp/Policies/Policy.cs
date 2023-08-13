using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    public interface Policy
    {
        void Execute(InventoryItem item);
    }
}
