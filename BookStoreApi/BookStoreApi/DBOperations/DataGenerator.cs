using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookStoreApi.DBOperations
{
    public class DataGenerator
    {
       
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                var authors = new List<Author>
                {
                    new Author { Name = "Eric Ries", DateOfBirth = new DateTime(1969, 09, 22) },
                    new Author { Name = "Paulo Coelho", DateOfBirth = new DateTime(1947, 08, 24) },
                    new Author { Name = "J. K. Rowling", DateOfBirth = new DateTime(1965, 07, 31) },
                    new Author { Name = "Harper Lee", DateOfBirth = new DateTime(1926, 04, 28) },
                    new Author { Name = "George Orwell", DateOfBirth = new DateTime(1903, 06, 25) },
                    new Author { Name = "F. Scott Fitzgerald", DateOfBirth = new DateTime(1896, 09, 24) }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();

                var genres = new List<Genre>
                {
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Novel" }
                };
                context.Genres.AddRange(genres);
                context.SaveChanges();

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        PageCount = 200,
                        PublishDate = new DateTime(2011, 06, 12),
                        GenreId = genres[0].Id,
                        AuthorId = authors[0].Id
                    },
                     new Book
                     {
                         Title = "The Alchemist",
                         PageCount = 208,
                         PublishDate = new DateTime(1988, 04, 25),
                         GenreId = genres[1].Id,
                         AuthorId = authors[1].Id
                     },
                     new Book
                     {
                         Title = "Harry Potter and the Sorcerer's Stone",
                         PageCount = 320,
                         PublishDate = new DateTime(1997, 06, 26),
                         GenreId = genres[1].Id,
                         AuthorId = authors[2].Id
                     },
                      new Book
                      {
                          Title = "To Kill a Mockingbird",
                          PageCount = 336,
                          PublishDate = new DateTime(1960, 07, 11),
                          GenreId = genres[2].Id,
                          AuthorId = authors[3].Id

                      },
                      new Book
                      {
                          Title = "1984",
                          PageCount = 328,
                          PublishDate = new DateTime(1949, 06, 08),
                          GenreId = genres[1].Id,
                          AuthorId = authors[4].Id
                      },
                      new Book
                      {
                          Title = "The Great Gatsby",
                          PageCount = 180,
                          PublishDate = new DateTime(1925, 04, 10),
                          GenreId = genres[2].Id,
                          AuthorId = authors[5].Id
                      },
                      new Book
                      {
                          Title = "Harry Potter and the Deathly Hallows",
                          PageCount = 607,
                          PublishDate = new DateTime(2007, 07, 21),
                          GenreId = genres[1].Id,
                          AuthorId = authors[2].Id

                      }
                      ) ;

                context.SaveChanges();


            }
        }
    }
}
