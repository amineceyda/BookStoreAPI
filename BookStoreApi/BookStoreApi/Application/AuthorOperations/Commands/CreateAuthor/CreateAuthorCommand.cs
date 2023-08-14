using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public CreateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=> x.Name.ToLower() == Model.Name.ToLower());
            if (author is not null)
                throw new InvalidOperationException("Bu isimde bir yazar zaten mevcut");

            author = new Author();
            author.Name = Model.Name;

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
    }
}
