using AutoMapper;
using BookStoreApi.Application.BookOperations.Commands.CreateBooks;
using BookStoreApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreApi.Application.BookOperations.Querys.GetBookDetail;
using BookStoreApi.Application.BookOperations.Querys.GetBooks;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get method for read all book
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //Get method for read single book by id
        [HttpGet("{id}")]//api/books/1
        public IActionResult GetById(int id)
        {
            GenreDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            //Artık try catch ile değil response da hata fırlatırsa bunu middleware ile yakalıyorum.
            //try { }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);  
            //}

            return Ok(result);
            
        }


        //Post method for create new book
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = newBook;

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            //ValidationResult result =validator.Validate(command);

            validator.ValidateAndThrow(command);

            //if (!result.IsValid)
            //    foreach(var item in result.Errors)
            //        Console.WriteLine("Özellik: " + item.PropertyName + "Error Message: "+ item.ErrorMessage);//Hangi alanda hata aldığımızı söyler ve ne hatası aldığımız içinde errorMessage
            //else
            //    command.Handle();

            command.Handle();
            return Ok();
        }

        //Put method for update a book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        //Delete method dor delete a book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
        
    }
}
