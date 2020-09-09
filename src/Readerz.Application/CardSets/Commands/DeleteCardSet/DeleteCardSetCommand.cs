using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Readerz.Application.Common.Exceptions;
using Readerz.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Readerz.Application.CardSets.Commands.DeleteCardSet
{
    public class DeleteCardSetCommand : IRequest
    {
        public int CardSetId { get; set; }
    }
    
    public class DeleteCardSetCommandHandler : IRequestHandler<DeleteCardSetCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCardSetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCardSetCommand request, CancellationToken cancellationToken)
        {
            var cardSet = await _context.CardSets.FindAsync(request.CardSetId);

            if (cardSet == null)
            {
                throw new NotFoundException(nameof(CardSet), request.CardSetId);
            }

            _context.CardSets.Remove(cardSet);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}