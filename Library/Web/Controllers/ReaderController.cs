using Application.Filters;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[BasicAuthorizeAttribute()]
	public class ReaderController(IReaderService readerService, IBookService bookService, IUserReadingService userReadingService) : Controller
    {
        private readonly IReaderService readerService = readerService;
        private readonly IBookService bookService = bookService;
        private readonly IUserReadingService usersReadingService = userReadingService;

        [HttpGet]
        public IActionResult Save(int id)
        {
            BookDto bookDto = new BookDto();
            Reader reader = new Reader();
            bookDto.Book = bookService.GetBook(id);
            if (!bookDto.Book.InTheLibrary)
            {
                bookDto.Reader = readerService.GetReader(bookDto.Book.UserReading.ReaderID);
            }
            else
            {
				bookDto.ExpirationDate = DateTime.Now.AddDays(14);
				bookDto.Book.UserReading = new UserReading();
                bookDto.Book.UserReading.ReaderID = 0;                
                bookDto.Book.UserReading.Reader = new Reader();
            }
            return View(bookDto);
        }

        [HttpPost]
        public IActionResult Save(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                UserReading userReading = new UserReading();
                if (bookDto != null)
                {
                    SetBookDto(bookDto);
                    userReading.ReaderID = bookDto.Reader.ID;
                    userReading.BookID = bookDto.Book.ID;
                    userReading.UpdateDate = DateTime.Now;
                    userReading.ExpirationDate = bookDto.ExpirationDate;
                    userReading = usersReadingService.SaveUserReading(userReading);
                    if (bookDto != null && userReading.ID > 0)
                    {
                        bookDto.Success = true;
                    }
                    bookDto.Book.UserReading.Reader = bookDto.Reader;
                }
            }
            return View(bookDto);
        }

        private BookDto SetBookDto(BookDto bookDto)
        {
			bookDto.Reader = bookDto.Book.UserReading.Reader;
			bookDto.Reader.UpdateDate = DateTime.Now;
			bookDto.Reader = readerService.SaveReader(bookDto.Reader);
			bookDto.Book = bookService.GetBook(bookDto.Book.ID);
			bookDto.Book.UpdateDate = DateTime.Now;
			bookDto.Book.InTheLibrary = false;
			bookDto.Book = bookService.SaveBook(bookDto.Book);
            return bookDto;
		}
    }
}
