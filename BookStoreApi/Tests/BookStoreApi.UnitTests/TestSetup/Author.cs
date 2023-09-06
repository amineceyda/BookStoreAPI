using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.UnitTests.TestSetup;

public static class Authors
{
    public static void AddAuthors(this BookStoreDbContext context)
    {
        context.Authors.AddRange(
            new Author { Name = "Eric Ries", DateOfBirth = new DateTime(1969, 09, 22) },
            new Author { Name = "Paulo Coelho", DateOfBirth = new DateTime(1947, 08, 24) },
            new Author { Name = "J. K. Rowling", DateOfBirth = new DateTime(1965, 07, 31) },
            new Author { Name = "Harper Lee", DateOfBirth = new DateTime(1926, 04, 28) },
            new Author { Name = "George Orwell", DateOfBirth = new DateTime(1903, 06, 25) },
            new Author { Name = "F. Scott Fitzgerald", DateOfBirth = new DateTime(1896, 09, 24) }        


            );
    }
}