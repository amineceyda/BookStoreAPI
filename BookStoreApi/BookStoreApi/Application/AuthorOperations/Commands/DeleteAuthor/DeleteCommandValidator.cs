using FluentValidation;

namespace BookStoreApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteCommandValidator() 
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
