using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Commands.DeleteCommand
{
    public class DeleteCardSetCommandHandler : IRequestHandler<DeleteCardSetCommand, DeleteCardSetCommand>
    {
        private readonly IReaderzDbContext _context;

        public DeleteCardSetCommandHandler(IReaderzDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCardSetCommand> Handle(DeleteCardSetCommand request, CancellationToken cancellationToken)
        {
            var cardSet = await _context.CardSets.FindAsync(request.CardSetId);

            if (cardSet == null)
            {
                throw new NotFoundException(nameof(CardSet), request.CardSetId);
            }

            _context.CardSets.Remove(cardSet);

            await _context.SaveChangesAsync(cancellationToken);
            
            return request;
        }
    }
}