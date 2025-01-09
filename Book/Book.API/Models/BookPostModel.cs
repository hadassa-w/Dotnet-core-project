using Books.Core.Models;

namespace Books.API.Models
{
    public class BookPostModel
    {
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public int CountPages { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime DateWrite { get; set; }
        public bool Status { get; set; }
        public int BookBuyerId { get; set; }
        public int BookSellerId { get; set; }
        //public BookBuyer BookBuyer { get; set; }
        //public BookSeller BookSeller { get; set; }
    }
}
