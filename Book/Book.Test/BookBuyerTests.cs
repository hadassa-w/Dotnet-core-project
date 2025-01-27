using Books.Core.Models;
using Books.Core.Services;

namespace Books.Test
{
    public class BookBuyerTests
    {
        private readonly IBookBuyerService _bookBuyerService;
        public BookBuyerTests(IBookBuyerService bookBuyerService)
        {
            _bookBuyerService = bookBuyerService;
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            //Arrange

            //Act
            var result = _bookBuyerService.GetAllAsync();

            //Assert
            Assert.IsType<List<BookBuyer>>(result);
        }

        [Fact]
        public void Get_Id_IsOk()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _bookBuyerService.GetById(id);

            //Assert
            Assert.IsType<BookBuyer>(result);
        }

        [Fact]
        public void Get_Service_IsOk()
        {
            //Arrange
            //DateTime dateTime = new DateTime();

            //Act
            var result = _bookBuyerService.GetType();

            //Assert
            Assert.IsType<IBookBuyerService>(result);
        }
    }
}
