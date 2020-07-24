using MediatR;

namespace Reader.Application.CardSets.Commands.DeleteCommand
{
    public class DeleteCardSetCommand : IRequest<DeleteCardSetCommand>
    {
        public int CardSetId { get; set; }
        public string Status { get; set; } = "Deleted";
    }
}