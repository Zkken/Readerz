using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Cards.Queries.GetCardsByCardSet;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.Cards.Commands.UpdateCard
{
    public class UpdateCardCommand : IRequest
    {
        public CardDto CardDto { get; set; } 
        
        public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateCardCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
            {
                if (request.CardDto == null)
                {
                    throw new ArgumentNullException(nameof(request.CardDto));
                }
                
                var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == request.CardDto.Id, 
                    cancellationToken: cancellationToken);

                if (card == null)
                {
                    throw new NotFoundException(nameof(Card), request.CardDto.Id);
                }

                card.Id = request.CardDto.Id;
                card.Front = request.CardDto.Front;
                card.Back = request.CardDto.Back;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}