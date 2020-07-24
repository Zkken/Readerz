using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Common.Interfaces;

namespace Reader.Application.CardCreator.Queries.GetCardCreatorId
{
    public class GetCardCreatorIdQuery : IRequest<int?>
    {

        public class GetCardCreatorIdQueryHandler : IRequestHandler<GetCardCreatorIdQuery, int?>
        {
            private readonly IReaderzDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public GetCardCreatorIdQueryHandler(IReaderzDbContext context, 
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int?> Handle(GetCardCreatorIdQuery request, CancellationToken cancellationToken)
            {
                var cardCreator = await _context.CardCreators
                    .FirstOrDefaultAsync(c => c.UserId == _currentUserService.UserId, cancellationToken);

                return cardCreator?.CardCreatorId;
            }
        }
    }
}