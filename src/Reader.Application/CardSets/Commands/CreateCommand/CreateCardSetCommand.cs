using MediatR;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    class CreateCardSetCommand : IRequest
    {
        public int Id { get; set; }


    }
}
