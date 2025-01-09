using Books.Core.Models;

namespace Books.API.Models
{
    public class BookBuyerPostModel
    {
        public string FullName { get; set; }
        public int Phone { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //public List<int> BooksId { get; set; }
    }
}
