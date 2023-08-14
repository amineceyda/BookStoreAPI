using FluentValidation;

namespace BookStoreApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator() {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
         }
    }
}
