using FluentValidation;

namespace Reader.Application.Cards.Commands.CreateCardRange
{
    public class CreateCardRangeValidator : AbstractValidator<CreateCardRangeCommand>
    {
        public CreateCardRangeValidator()
        {
            RuleFor(prop => prop.Cards)
                .NotNull()
                .ForEach(cardDto => cardDto.SetValidator(new CardDtoValidator()));
        }
    }

    public class CardDtoValidator : AbstractValidator<CardDto>
    {
        public CardDtoValidator()
        {
            RuleFor(prop => prop.Front)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);
            
            RuleFor(prop => prop.Back)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);
        }
    }
}