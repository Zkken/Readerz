using FluentValidation;

namespace Readerz.Application.Text.Queries.GetProcessedText
{
    public class GetProcessedTextValidator : AbstractValidator<GetProcessedTextQuery>
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