using MediatR;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQuery : IRequest<CardSetVm>
    {
        public string UserId { get; set; }
    }
}