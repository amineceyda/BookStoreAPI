using AutoMapper;
using BookStoreApi.Common;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Querys.GetBookDetail
{
    public class GetBookDetailQuery
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            GenreDetailViewModel viewModel = _mapper.Map<GenreDetailViewModel>(book);
            /* bunları AutoMapper yapacak
            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title = book.Title;
            viewModel.PageCount = book.PageCount;
            viewModel.PublishDate = book.PublishDate.ToString("dd/MM/yyy");
            viewModel.Genre = ((GenreEnum)book.GenreId).ToString();*/

            return viewModel;
        }
    }

    public class GenreDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }  

        public int PageCount { get; set; }

        public string PublishDate { get; set; }
    }
}
