using FluentValidation;

namespace Reader.Application.Cards.Commands.UpdateCard
{
    public class UpdateCardValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardValidator()
        {
            RuleFor(prop => prop.Front)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30)
                .MinimumLength(2);

            RuleFor(prop => prop.Back)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30)
                .MinimumLength(2);
        }
    }
}