using FluentValidation;
using Readerz.Application.Text.Queries.GetWordItems;

namespace Readerz.Application.Text.Queries.GetProcessedText
{
    public class GetProcessedTextValidator : AbstractValidator<GetWordItemsQuery>
    {
        public GetProcessedTextValidator()
        {
            RuleFor(prop => prop.Text)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(10000);
        }
    }
}