namespace SuperZapatos.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;

    public class StoreConfiguration : EntityTypeConfiguration<Store>
    {

        public StoreConfiguration()
        {

            ToTable("Stores");

            HasKey(k => k.Id);
            Property(p => p.Name).IsRequired();
            Property(p => p.Address).IsOptional();
            
            //HasMany(store => store.Articles).WithRequired().HasForeignKey(article => article.Store_Id).WillCascadeOnDelete(true);

        }

    }
}
