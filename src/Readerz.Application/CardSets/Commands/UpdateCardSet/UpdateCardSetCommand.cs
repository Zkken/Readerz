using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Readerz.Application.Common.Exceptions;
using Readerz.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using Readerz.Web.Domain.Enums;

namespace Readerz.Application.CardSets.Commands.UpdateCardSet
{
    public class UpdateCardSetCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
    }
    
    public class UpdateCardSetCommandHandler : IRequestHandler<UpdateCardSetCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCardSetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCardSetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CardSets.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardSet), request.Id);
            }
            
            entity.Name = request.Name;
            entity.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}