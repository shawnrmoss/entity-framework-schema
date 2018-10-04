using EntityFrameworkSchema.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSchema.Data.Configurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            Map(m => m.MapInheritedProperties());
            ToTable(nameof(ILibraryDbContext.Books), LibraryDbContext.DefaultSchema);
            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Title).IsRequired().HasMaxLength(65);

            // Foreign keys            
            HasRequired(a => a.Author).WithMany().HasForeignKey(c => c.AuthorId).WillCascadeOnDelete(false);
        }
    }
}
