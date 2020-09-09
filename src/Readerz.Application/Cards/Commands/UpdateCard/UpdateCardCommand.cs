using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Readerz.Application.Common.Exceptions;
using Readerz.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Readerz.Application.Cards.Commands.UpdateCard
{
    public class UpdateCardCommand : IRequest
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
    }

    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCardCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (card == null)
            {
                throw new NotFoundException(nameof(Card), request.Id);
            }

            card.Id = request.Id;
            card.Front = request.Front;
            card.Back = request.Back;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}