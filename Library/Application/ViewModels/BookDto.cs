using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModels
{
    //ViewModeller son kullanıcıya gösterilecek verileri döndürmek için kullandığımız modellerimizdir.
    public class BookDto
    {
        public List<Book> Books { get; set; }
        public List<BookType> BookTypes { get; set; }
        public Book Book { get; set; }
        public int BookTypeID {  get; set; }
        public bool OutSide {  get; set; }
        public bool Success {  get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(14);
        public Reader Reader { get; set; }
        public IFormFile FormFile { get; set; }
	}
}
