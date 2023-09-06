using BookStoreApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreApi.DBOperations;
using BookStoreApi.Entities;
using BookStoreApi.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreApi.UnitTests.Application.BookOperations.Commands.DeleteBook;

public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    public int BookId { get; set; }
    public DeleteBookCommandTest(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
    }

    [Fact]
    public void WhenGivenTheNonExistBook_InvalidOperationException_ShouldReturn()
    {
        //arrange 
        var nonExistBookId = -1; //hata

        //act&assert
        var command = new DeleteBookCommand(_context);
        command.BookId = nonExistBookId;

        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı");

    }

    [Fact]
    public void WhenValidInputGiven_Book_ShouldDeleted()
    {
        //arrange -> ilk yeni kitap oluştur sonra delete command için instance ver
        var book = new Book() { Title = "Lord Of The Rings", PageCount = 100, PublishDate = new System.DateTime(1990, 05, 22), GenreId = 1, AuthorId = 1 };
        _context.Add(book);
        _context.SaveChanges();

        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = book.Id;

        //act
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();

        //assert //doğrulama için aynı id ile kitap bulunmaması lazım
        book = _context.Books.SingleOrDefault(x => x.Id == book.Id);
        book.Should().BeNull();

    }
}
