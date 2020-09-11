using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Readerz.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using Readerz.Web.Domain.Enums;

namespace Readerz.Application.CardSets.Commands.CreateCardSet
{
    public class CreateCardSetCommand : IRequest<int>
    {
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
    }
    
    public class CreateCardSetCommandHandler : IRequestHandler<CreateCardSetCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateCardSetCommandHandler> _logger;

        public CreateCardSetCommandHandler(IApplicationDbContext context, ILogger<CreateCardSetCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCardSetCommand request, CancellationToken cancellationToken)
        {
            var cardSet = new CardSet
            {
                Name = request.Name,
                Status = request.Status,
                TextId = request.TextId,
            };
            
            _context.CardSets.Add(cardSet);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return cardSet.Id;
        }
    }
}
