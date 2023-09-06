using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");

            if (_dbContext.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Aynı isimli bir yazar zaten mevcut");

            author.Name = Model.Name.Trim() != default ? Model.Name : author.Name;
            author.IsActive = Model.IsActive;
            _dbContext.SaveChanges();


        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
