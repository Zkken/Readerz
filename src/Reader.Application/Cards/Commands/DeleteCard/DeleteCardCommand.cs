using MediatR;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Exceptions;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Interfaces;
using Readerz.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Cards.Commands.DeleteCard
{
    public class DeleteCardCommand : IRequest
    {
        public int Id { get; set; }
    }
    
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCardCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cards.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Card), request.Id);
            }

            _context.Cards.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
