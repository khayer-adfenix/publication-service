using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdFenix.Entities.DomainObject;
using AdFenix.InfrastructureNetCore;
using ConsumerService.DatabaseContext;
using dFenix.InfrastructureNetCore;

namespace ConsumerService.Handlers
{
    public class AddPublicationOwnerCommandHandler:IActionCommandHandler<AddPublicationOwnerCommand>
    {
        private AdFenixDbConext adFenixDbConext;

        public AddPublicationOwnerCommandHandler(AdFenixDbConext adFenixDbConext)
        {
            this.adFenixDbConext = adFenixDbConext;


        }
        public async Task Handle(AddPublicationOwnerCommand command)
        {
            try
            {
                var publicationOwner = new PublicationOwner()
                {
                    HostUrl = command.HostUrl,
                    Name = command.Name
                };
                this.adFenixDbConext.Add(publicationOwner);
                this.adFenixDbConext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"[AddPublicationOwnerCommandHandler.Handle] : {command.Name}");
        }
    }
}
