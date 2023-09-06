using System;
using System.Linq;
using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");

            if (author.Books.Any())
                throw new InvalidOperationException("Yazarın yayınlanmış kitapları bulunuyor. Önce kitapları silin.");

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
