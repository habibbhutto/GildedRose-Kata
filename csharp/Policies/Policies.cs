using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Policies
{
    public class Policies
    {
        private static IDictionary<string, Policy> policies;

        public static Policy GetPolicy(string id)
        {
            if(policies is null)
            {
                policies = new Dictionary<string, Policy>();
                policies.Add(AgedBriePolicy.ID, new AgedBriePolicy());
                policies.Add(BackstagePassesPolicy.ID, new BackstagePassesPolicy());
                policies.Add(SulfurasPolicy.ID, new SulfurasPolicy());
                policies.Add(GenericPolicy.ID, new GenericPolicy());
            }

            Policy policy;
            if (policies.TryGetValue(id, out policy))
            {
                return policy;
            }

            return policies[GenericPolicy.ID];
        }
    }
}
