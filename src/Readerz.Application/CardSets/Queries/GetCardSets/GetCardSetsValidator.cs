using FluentValidation;

namespace Readerz.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsValidator : AbstractValidator<GetCardSetsQuery>
    {
        public GetCardSetsValidator()
        {
            RuleFor(prop => prop.PageIndex)
                .GreaterThanOrEqualTo(0);

            RuleFor(prop => prop.PageSize)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

        }
    }
}