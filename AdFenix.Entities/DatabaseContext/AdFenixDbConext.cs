using System;
using System.Collections.Generic;
using System.Text;
using AdFenix.Entities.DomainObject;
using Microsoft.EntityFrameworkCore;

namespace AdFenix.Entities.DatabaseContext
{
    public class AdFenixDbConext : DbContext
    {
        public DbSet<PublicationOwner> PublicationOwners { get; set; }

        public AdFenixDbConext(DbContextOptions<AdFenixDbConext> options) : base(options)
        {
            
            Database.Migrate();

        }
    }
}
