using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSchema.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        // Navigational Properties
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
