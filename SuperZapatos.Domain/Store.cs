namespace SuperZapatos.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Store : Entity
    {
        public Store()
        {
            Articles = new List<Article>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Article> Articles { get; set; }



    }
}
