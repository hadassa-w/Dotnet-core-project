using Books.Core.Models;
using Books.Core.Services;

namespace Books.Test
{
    public class BookSellerTests
    {
        private readonly IBookSellerService _bookSellerService;
        public BookSellerTests(IBookSellerService bookSellerService)
        {
            _bookSellerService = bookSellerService;
        }

        [Fact]
        public void GetAll_ReturnOk()
        {
            //Arrange

            //Act
            var result = _bookSellerService.GetAll();

            //Assert
            Assert.IsType<List<BookSeller>>(result);
        }

        [Fact]
        public void Get_Id_IsOk()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _bookSellerService.GetById(id);

            //Assert
            Assert.IsType<BookSeller>(result);
        }

        [Fact]
        public void Get_Service_IsOk()
        {
            //Arrange
            //DateTime dateTime = new DateTime();

            //Act
            var result = _bookSellerService.GetType();

            //Assert
            Assert.IsType<IBookSellerService>(result);
        }
    }
}
