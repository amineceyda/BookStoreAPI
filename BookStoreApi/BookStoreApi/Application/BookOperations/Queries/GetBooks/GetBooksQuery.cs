﻿using AutoMapper;
using BookStoreApi.Common;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Querys.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books
                .Include(book => book.Genre)
                .Include(book => book.Author)
                .OrderBy(x => x.Id)
                .ToList();

            List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookList);

            /* Her kitap için dönüşüm yapıyorduk buna gerek yok şimdi
            
            List<BooksViewModel> viewModel = new List<BooksViewModel>();

            foreach (var book in bookList)
            {
                viewModel.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),

                });
            }*/
            return viewModel;
        }
    }

    public class BooksViewModel //UI kısmında ne göstermek istiyorsun
    {
        public string Title { get; set; }
        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }  


    }
}
