using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    public class CreateCardSetCommandHandler : IRequestHandler<CreateCardSetCommand, int>
    {
        private readonly IReaderzDbContext _context;
        
        public CreateCardSetCommandHandler(IReaderzDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCardSetCommand request, CancellationToken cancellationToken)
        {
            var entity = new CardSet
            {
                Name = request.Name,
                Status = request.Status,
                TextId = request.TextId
            };

            _context.CardSets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}