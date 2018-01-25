using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdFenix.InfrastructureNetCore;
using dFenix.InfrastructureNetCore;

namespace ConsumerService.Handlers
{
    public class AddPublicationOwnerCommandHandler:IActionCommandHandler<AddPublicationOwnerCommand>
    {
        public async Task Handle(AddPublicationOwnerCommand command)
        {
            Console.WriteLine($"[AddPublicationOwnerCommandHandler.Handle] : {command.Name}");
        }
    }
}
