using EntityFrameworkSchema.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkSchema.Data
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public static string DefaultSchema = "library";

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public LibraryDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Migrations.Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set the default schema
            modelBuilder.HasDefaultSchema(DefaultSchema);

            // Prevent cascade deleting
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Include all the configurations in the current assembly
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }

    public class LibraryDbContextFactory : IDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            return new LibraryDbContext(connectionString);
        }
    }

}
