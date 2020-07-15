using MediatR;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    public class CreateCardSetCommand : IRequest<int>
    {
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
    }
}
