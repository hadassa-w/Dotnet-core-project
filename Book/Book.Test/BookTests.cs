using Books.Core.Models;
using Books.Core.Services;

namespace Books.Test
{
    public class BookTests
    {
        private readonly IBookService _bookService;
        public BookTests(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Fact]
        public void GetAll_ReturnOk()
        {
            //Arrange

            //Act
            var result = _bookService.GetAll();

            //Assert
            Assert.IsType<List<Book>>(result);
        }

        [Fact]
        public void Get_Id_IsOk()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _bookService.GetById(id);

            //Assert
            Assert.IsType<Book>(result);
        }

        [Fact]
        public void Get_Service_IsOk()
        {
            //Arrange
            //DateTime dateTime = new DateTime();

            //Act
            var result = _bookService.GetType();

            //Assert
            Assert.IsType<IBookService>(result);
        }
    }
}
