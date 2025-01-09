using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.DTOs
{
    public class BookBuyerDTO
    {
        public string FullName { get; set; }
        public int Phone { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //public List<BookDTO> Books { get; set; }
    }
}
