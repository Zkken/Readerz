using System.Collections.Generic;
using MediatR;
using Reader.Application.Cards.Queries.GetCardsByCardSet;

namespace Reader.Application.Cards.Commands.CreateRangeCommand
{
    public class CreateCardRangeCommand : IRequest
    {
        public int CardSetId { get; set; }
        public ICollection<CardDto> CardDtos { get; set; }
    }
}