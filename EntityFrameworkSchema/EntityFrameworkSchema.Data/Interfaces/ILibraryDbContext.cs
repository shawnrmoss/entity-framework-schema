using EntityFrameworkSchema.Data.Models;
using System.Data.Entity;

namespace EntityFrameworkSchema.Data
{
    public interface ILibraryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}
