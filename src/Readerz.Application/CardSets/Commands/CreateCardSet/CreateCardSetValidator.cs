using FluentValidation;

namespace Readerz.Application.CardSets.Commands.CreateCardSet
{
    public class CreateCardSetValidator : AbstractValidator<CreateCardSetCommand>
    {
        public CreateCardSetValidator()
        {
            RuleFor(prop => prop.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);
        }
    }
}