namespace SuperZapatos.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article : Entity
    {

        

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public decimal Total_in_Shelf { get; set; }

        public decimal Total_in_Vault { get; set; }

        public long Store_Id { get; set; }

        public virtual Store Store{ get; set; }





    }
}
