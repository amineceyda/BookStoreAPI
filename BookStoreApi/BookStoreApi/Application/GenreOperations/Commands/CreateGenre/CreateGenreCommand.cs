using AutoMapper;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Kitap Türü Zaten Mevcut");

            //map kullanmak istemiyorsak
            genre = new Genre();
            genre.Name = Model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
