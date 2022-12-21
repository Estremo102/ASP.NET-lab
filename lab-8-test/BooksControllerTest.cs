using lab_8;
using lab_8.Controllers;
using lab_8.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace lab_8_test
{
    public class BooksControllerTest
    {
        private readonly BooksController controller;
        private readonly IBookService service = new BookServiceTest();

        public BooksControllerTest()
        {
            //this.service = service;
            service.Save(new Book() { Id = 1, Title = "ABC" });
            service.Save(new Book() { Id = 2, Title = "def" });
            service.Save(new Book() { Id = 3, Title = "gHi" });
            controller = new BooksController(service);
        }

        [Fact]
        public void GetTest()
        {
            ActionResult<Book> actionResult = controller.Get(1);
            Book book = Assert.IsType<Book>(actionResult.Value);
            Assert.Equal(book.Id, service.FindBy(book.Id).Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(null)]
        public void GetByIdTest(int id)
        {
            ActionResult<Book> actionResult = controller.Get(id);
            if (actionResult.Value == null)
            {
                bool contains = false;
                foreach(Book b in service.FindAll())
                {
                    if(b.Id == id)
                    {
                        contains = true;
                    }
                }
                Assert.True(!contains);
            }
            else
            {
                Book book = Assert.IsType<Book>(actionResult.Value);
                Assert.Equal(book.Id, service.FindBy(book.Id).Id);
            }
        }

        [Fact]
        public void PostTest()
        {
            Book newBook = new Book() { Title = "Langosz"};
            int id = service.Save(newBook);
            ActionResult<Book> actionResult = controller.Get(id);
            if (actionResult.Value == null)
            {
                bool contains = false;
                foreach (Book b in service.FindAll())
                {
                    if (b.Id == id)
                    {
                        contains = true;
                    }
                }
                Assert.True(!contains);
            }
            else
            {
                Book book = Assert.IsType<Book>(actionResult.Value);
                Assert.Equal(book.Id, service.FindBy(book.Id).Id);
            }
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void DeleteTest(int id)
        {
            bool contains = false;
            foreach (Book b in service.FindAll())
            {
                if (b.Id == id)
                {
                    contains = true;
                }
            }
            if (contains)
            {
                Assert.True(service.Delete(id));
            }
            else
            {
                Assert.False(service.Delete(id));
            }
        }
    }
}
