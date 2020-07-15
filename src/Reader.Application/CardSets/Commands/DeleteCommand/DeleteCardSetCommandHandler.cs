using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Commands.DeleteCommand
{
    public class DeleteCardSetCommandHandler : IRequestHandler<DeleteCardSetCommand>
    {
        private readonly IReaderzDbContext _context;

        public DeleteCardSetCommandHandler(IReaderzDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCardSetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CardSets.FindAsync(request.CardSetId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardSet), request.CardSetId);
            }

            _context.CardSets.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}