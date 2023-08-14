using AutoMapper;
using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.IsActive && x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");

            AuthorDetailViewModel returnObj = _mapper.Map<AuthorDetailViewModel>(author);

            return returnObj;

        }
    }

    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
