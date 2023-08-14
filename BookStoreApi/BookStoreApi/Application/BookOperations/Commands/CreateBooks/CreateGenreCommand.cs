using AutoMapper;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Commands.CreateBooks
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = _mapper.Map<Book>(Model); //Bu alttaki işlemleri otamatik yapar 

            //Ya da gelen modeli book objesine dönüştürür diyelim
            //book = new Entities.Book();
            /*
            //Bu bizim normal mapper işlemlerimizdi.AutoMapper ile otamatikleştirdik
            book.Title = Model.Title;
            book.PublishDate = Model.PublisDate;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;*/ //Yani buna ihtiyaç yok artık onun yerine



            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublisDate { get; set; }
    }
}
