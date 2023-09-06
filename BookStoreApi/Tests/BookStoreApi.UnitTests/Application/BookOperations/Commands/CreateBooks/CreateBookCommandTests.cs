using AutoMapper;
using BookStoreApi.Application.BookOperations.Commands.CreateBooks;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using BookStoreApi.UnitTests.TestSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Commands.CreateBooks;

public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    // genellikle testler geriye bir şey dönmez , Fact komutu ile de fonksiyonun test olduğunu belirtirsin
    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn()
    {
        //arrange -hazırla
        var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, AuthorId = 5 };
        _context.Books.Add(book);
        _context.SaveChanges();

        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.Model = new CreateBookModel() { Title = book.Title };//Bu test için sadece title'a ihtiyacım var

        //act -çalıştır
        //assert -doğrula
        //fleunt assertion kullanarak ikisini aynı anda yapabilirim
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
    }

    public void WhenValidInputAreGiven_Book_ShouldBeCreated()
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand( _context, _mapper);
        CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1, AuthorId = 2 };
        command.Model = model;
        //act&assert
        FluentActions.Invoking(() => command.Handle()).Invoke();
        var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);

        book.Should().NotBeNull();
        book.PageCount.Should().Be(model.PageCount);
        book.PublishDate.Should().Be(model.PublishDate);
        book.GenreId.Should().Be(model.GenreId);
        book.AuthorId.Should().Be(model.AuthorId);

    }

}
