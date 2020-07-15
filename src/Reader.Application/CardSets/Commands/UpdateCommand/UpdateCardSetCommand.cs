using MediatR;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Commands.UpdateCommand
{
    public class UpdateCardSetCommand : IRequest
    {
        public int CardSetId { get; set; }
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
    }
}