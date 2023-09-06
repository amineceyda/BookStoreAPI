
using BookStoreApi.Application.BookOperations.Commands.CreateBooks;
using BookStoreApi.UnitTests.TestSetup;
using FluentAssertions;

namespace BookStoreApi.UnitTests.Application.BookOperations.Commands.CreateBooks;

public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("Lord of the ring",0,0,0)]
    [InlineData("Lord of the ring", 0, 1, 1)]
    [InlineData("Lord of the ring", 300, 1, 1)]
    [InlineData("Lord of the ring", 300, 1, 0)]
    [InlineData("", 0, 0, 0)]
    [InlineData("", 300, 1, 1)]
    [InlineData("", 300, 0, 1)]
    [InlineData("", 300, 1, 0)]
    [InlineData("", 0, 1, 1)]
    [InlineData("Lord", 300, 1, 1)]
    [InlineData("Lord", 0, 0, 1)]
    [InlineData("Lord", 300, 0, 1)]
    [InlineData("Lord", 300, 1, 0)]
    [InlineData("Lord", 0, 1, 1)]//Burası ne denemek istediğine göre artabilir
    public void WhenValidInputsAreGiven_Validator_ShouldBeReturnError(string title,int pageCount, int genreId, int authorId)
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(null, null); //Methodu çalıştırmıyorum bu yüzden null göndersemde olur
        command.Model = new CreateBookModel()
        {
            Title = title,
            PageCount = pageCount,
            PublishDate = DateTime.Now.Date.AddYears(-1),//bunu null demek dependicy oluyor bu yüzden onun için ayrı test yazman gerek (fact)
            GenreId = genreId,
            AuthorId = authorId
        };
        //act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookModel()
        {
            Title = "Lord Of The Rings",
            PageCount = 100,
            PublishDate = DateTime.Now.Date,//hata //bir test içerisinde bir senaryo cover edilir
            GenreId = 1, //diğer değerler başarılı olmalı 
            AuthorId = 1
        };
        //act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    //Başarılı sonuçlarıda test etmelisin
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookModel()
        {
            Title = "Lord Of The Rings",
            PageCount = 100,
            PublishDate = DateTime.Now.Date.AddYears(-1),
            GenreId = 1
        };

        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().Be(0);
    }


}
