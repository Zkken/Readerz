using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Commands.UpdateCommand
{
    public class UpdateCardSetCommandHandler : IRequestHandler<UpdateCardSetCommand>
    {
        private readonly IReaderzDbContext _context;

        public UpdateCardSetCommandHandler(IReaderzDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCardSetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CardSets.FindAsync(request.CardSetId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardSet), request.CardSetId);
            }

            entity.Id = request.CardSetId;
            entity.Name = request.Name;
            entity.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}