using MediatR;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetQuery : IRequest<CardSetVm>
    {
        public string UserId { get; set; }
    }
}