using EntityFrameworkSchema.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkSchema.Data.Configurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Map(m => m.MapInheritedProperties());
            ToTable(nameof(ILibraryDbContext.Authors), LibraryDbContext.DefaultSchema);
            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            Property(x => x.FirstName).IsRequired().HasMaxLength(65);
            Property(x => x.LastName).IsRequired().HasMaxLength(65);           

            // Foreign keys            
            
        }
    }
}
