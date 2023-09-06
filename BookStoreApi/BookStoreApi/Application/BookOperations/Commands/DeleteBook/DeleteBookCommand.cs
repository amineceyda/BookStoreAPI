﻿using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BookStoreApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamadı");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }

}
