namespace SuperZapatos.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;
    
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {

        public ArticleConfiguration()
        {

            ToTable("Articles");
            HasKey<long>(k => k.Id);
            Property(p => p.Name).IsRequired();
            Property(p => p.Description).IsOptional();
            Property(p => p.Total_in_Shelf).IsRequired();
            Property(p => p.Total_in_Vault).IsRequired();
            Property(p => p.Store_Id).IsRequired();

            HasRequired(a => a.Store).WithMany(s => s.Articles).HasForeignKey(s => s.Store_Id);

        }
    }
}
