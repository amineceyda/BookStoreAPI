using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApi.UnitTests.TestSetup;

public static class Genres
{
    public static void AddGenres(this BookStoreDbContext context)
    {
        context.Genres.AddRange(
                new Genre { Name = "Personal Growth" },
                new Genre { Name = "Fiction" },
                new Genre { Name = "Novel" }

            );
    }
}