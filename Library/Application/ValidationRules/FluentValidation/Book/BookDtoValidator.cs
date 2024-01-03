using Application.Interfaces;
using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Book
{
	//ön yüzde doldurulan nesnelerin geçerliliğini FluentValidaitonlar aracılığıyla kontrol ediyoruz.
	public class BookDtoValidator : AbstractValidator<BookDto>
	{
		private readonly IBookService bookService;

		public BookDtoValidator(IBookService bookService)
		{
			this.bookService = bookService;
			RuleFor(m => new { m.Book.Name, m.Book.Author, m.Reader.ReaderName, m.Reader.ReaderSurname, m.Reader.PhoneNumber }).Must(x => ValidInventoryModel(x.Name, x.Author, x.ReaderName, x.ReaderSurname, x.PhoneNumber))
									 .WithMessage("Lütfen boş bir alan bırakmayınız.");
		}

		private bool ValidInventoryModel(string bookName, string author, string readerName, string readerSurname, string phoneNumber)
		{
			if (bookName != null && author != null && readerName != null && readerSurname != null && phoneNumber != null)
			{
				return true;
			}
			return false;
		}
	}
}
