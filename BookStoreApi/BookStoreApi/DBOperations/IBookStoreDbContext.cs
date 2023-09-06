using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.DBOperations;

public interface IBookStoreDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Author> Authors { get; set; }

    int SaveChanges();

}
//Bu interface'i oluşturmamızın sebebi en temelde unit test için bağımlılıklardan kurtulmak