using System.Collections.Generic;

namespace SuperZapatos.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class Stores
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember ]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Address { get; set; }
        
        public virtual ICollection<Articles> Articles { get; set; }

    }
}
