using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthors;
using BookStoreApi.Application.BookOperations.Commands.CreateBooks;
using BookStoreApi.Application.BookOperations.Querys.GetBookDetail;
using BookStoreApi.Application.BookOperations.Querys.GetBooks;
using BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreApi.Entities;

namespace BookStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, Application.BookOperations.Querys.GetBookDetail.GenreDetailViewModel>().ForMember(dest=> dest.Genre , opt=> opt.MapFrom(src=> src.Genre.Name ));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, Application.GenreOperations.Queries.GetGenreDetail.GenreDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();

        }
    }
}
