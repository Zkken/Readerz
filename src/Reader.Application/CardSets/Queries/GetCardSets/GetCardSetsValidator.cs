using FluentValidation;
using FluentValidation.Validators;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsValidator : AbstractValidator<GetCardSetsQuery>
    {
        public GetCardSetsValidator()
        {
            RuleFor(prop => prop.PageIndex)
                .GreaterThanOrEqualTo(1);

            RuleFor(prop => prop.PageSize)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

        }
    }
}