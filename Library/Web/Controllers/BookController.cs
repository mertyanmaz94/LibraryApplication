using Application.ConfigModels;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookController (IBookService bookService, IBookTypeService bookTypeService, ConfigModel configuration) : Controller
    {
        private readonly IBookService bookService = bookService;
        private readonly IBookTypeService bookTypeService = bookTypeService;
        private ConfigModel configuration = configuration;      

		[HttpGet]
        public IActionResult List()
        {
            BookDto bookDto = null;
            bookDto = new BookDto();
            bookDto.Books = bookService.GetBooks();
			bookDto.OutSide = this.ControlBooks(bookDto.Books);
			bookDto.BookTypes = bookTypeService.GetBookTypes();
            return View(bookDto);
        }

        [HttpPost]
        public IActionResult List(int bookTypeID)
        {
            BookDto bookDto = null;
            bookDto = new BookDto();
            if(bookTypeID > 0)
            {
                bookDto.Books = bookService.GetBooks(bookTypeID);
            }
            else
            {
                bookDto.Books = bookService.GetBooks();
            }
            bookDto.OutSide = this.ControlBooks(bookDto.Books);
            bookDto.BookTypes = bookTypeService.GetBookTypes();
            return View(bookDto); 
        }

        private bool ControlBooks(List<Book> books)
        {
            Reader reader = new Reader();
            bool outside = false;
            int count = 0;
            foreach (var book in books)
            {
                if (!book.InTheLibrary)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                outside = true;
            }
            return outside;
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            BookDto bookDto = new BookDto();
            if (id > 0)
            {
                bookDto.Book = bookService.GetBook(id);
            }
            bookDto.BookTypes = bookTypeService.GetBookTypes();
            return View(bookDto);
        }

        [HttpPost]
        public IActionResult Save(BookDto bookDto)
        {		
			if (ModelState.IsValid)
            {
				bookDto.BookTypes = bookTypeService.GetBookTypes();
				string uploadedFileName = bookDto.FormFile.FileName;
				string last = uploadedFileName.Split('.').Last();
				var guid = Guid.NewGuid().ToString();
				string fileName = guid + "." + last;
				string fileFolder = configuration.ImageFileUrl;
				if (bookDto.FormFile?.Length > 0)
				{
					var fullPath = Path.Combine(fileFolder, fileName);
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						bookDto.FormFile.CopyTo(stream);
					}
				}
				Book book = new();
                if (bookDto != null)
                {
                    if(bookDto.Book.UniqID == null)
                    {                    
                        bookDto.Book.UniqID = guid;
                        bookDto.Book.PictureUrl = fileName;
                        bookDto.Book.InTheLibrary = true;
						book = bookService.SaveBook(bookDto.Book);
					}
                    bookDto.Book.UpdateDate = DateTime.Now;
                    book = bookService.SaveBook(bookDto.Book);
                    if(book != null)
                    {
                        bookDto.Success = true;
                    }
                }
                return View(bookDto);
            }
            return View(bookDto);
        }        
    }
}
