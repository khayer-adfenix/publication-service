using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFenix.InfrastructureNetCore;

namespace AdFenix.InfrastructureNetCore
{
    public class AddPublicationOwnerCommand:IQueueCommand
    {
        public string Name { get; set; }
        public string HostUrl { get; set; }
    }
}
