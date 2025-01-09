using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Books.Core.Models
{
    public class Book
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
        //public int BookBuyerId { get; set; }
        public BookBuyer BookBuyer { get; set; }
        //public int BookSellerId { get; set; }
        public BookSeller BookSeller { get; set; }

        // one-to-many
        //public List<BookBuyer> BooksBuyers { get; set; }
        //public List<BookSeller> BooksSellers { get; set; }

        // many-to-many
        //public List<BookBuyer> BooksBuyers { get; set; }
        //public List<BookSeller> BooksSellers { get; set; }
    }
}
