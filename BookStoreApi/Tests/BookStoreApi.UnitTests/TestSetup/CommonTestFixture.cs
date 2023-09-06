using AutoMapper;
using BookStoreApi.Common;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.UnitTests.TestSetup;

public class CommonTestFixture
{
    
    public BookStoreDbContext Context { get; set; }
    public IMapper Mapper { get; set; }

    public CommonTestFixture()
    {

        var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
        Context = new BookStoreDbContext(options);

        Context.Database.EnsureCreated();

        Context.AddBooks();
        Context.AddGenres();
        Context.AddAuthors();
        Context.SaveChanges();

        //Mapper config ekle
        Mapper = new MapperConfiguration(cfg=> { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        
    }
}
