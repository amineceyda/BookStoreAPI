﻿using AutoMapper;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using BookStoreApi.Common;

namespace BookStoreApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {

        private readonly BookStoreDbContext _dbContext;

        public readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);

            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);

            return returnObj;
        }


    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
