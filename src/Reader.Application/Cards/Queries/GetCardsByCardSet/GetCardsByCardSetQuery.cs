using MediatR;

namespace Reader.Application.Cards.Queries.GetCardsByCardSet
{
    public class GetCardsByCardSetQuery : IRequest<CardListVm>
    {
        public int Id { get; set; }
    }
}
