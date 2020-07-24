using System.Collections;
using System.Collections.Generic;
using MediatR;
using Reader.Application.Cards.Queries.GetCardsByCardSet;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    public class CreateCardSetCommand : IRequest<int>
    {
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
    }
}
