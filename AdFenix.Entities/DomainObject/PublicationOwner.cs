using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdFenix.Entities.DomainObject
{
    public class PublicationOwner
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HostUrl { get; set; }
    }
}
