using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Models
{
    public class BookBuyer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // one-to-one
        //public int BookId { get; set; }
        //public Book Book { get; set; }

        // one-to-one / many-to-many
        public List<Book> Books { get; set; }
    }
}
