using FluentValidation;

namespace Reader.Application.CardSets.Commands.UpdateCardSet
{
    public class UpdateCardSetValidator : AbstractValidator<UpdateCardSetCommand>
    {
        public UpdateCardSetValidator()
        {
            RuleFor(prop => prop.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);
        }
    }
}