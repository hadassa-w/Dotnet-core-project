using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public int CountPages { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime DateWrite { get; set; }
        public bool Status { get; set; }

        // one-to-one
        public BookBuyerDTO BookBuyer { get; set; }
        //public int BookBuyerId { get; set; }
        //public BookBuyer BookBuyer { get; set; }
        public BookSellerDTO BookSeller { get; set; }
        //public int BookSellerId { get; set; }
        //public BookSeller BookSeller { get; set; }

    }
}
