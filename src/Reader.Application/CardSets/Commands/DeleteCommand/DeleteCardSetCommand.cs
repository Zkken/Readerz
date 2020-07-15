using MediatR;

namespace Reader.Application.CardSets.Commands.DeleteCommand
{
    public class DeleteCardSetCommand : IRequest
    {
        public int CardSetId { get; set; }
    }
}