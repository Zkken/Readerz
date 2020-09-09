using FluentValidation;

namespace Readerz.Application.Text.Queries.GetWordTranslation
{
    public class GetWordTranslationValidator : AbstractValidator<GetWordTranslationQuery>
    {
        public GetWordTranslationValidator()
        {
            RuleFor(prop => prop.From)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(5); //"zh-TW" Chinese Traditional.

            RuleFor(prop => prop.To)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(5);

            RuleFor(prop => prop.Text)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}