using MediatR;

namespace Reader.Application.Cards.Querries.GetCardsByCardSet
{
    public class GetCardsByCardSetQuery : IRequest<CardListVm>
    {
        public int Id { get; set; }
    }
}
