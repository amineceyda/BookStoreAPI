﻿using AutoMapper;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStoreApi.Common;

namespace BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap Türü bulunamadı");

            GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);

            return returnObj;
        }


    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
