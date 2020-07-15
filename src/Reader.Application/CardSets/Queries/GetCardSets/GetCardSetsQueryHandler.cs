using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reader.Application.Common.Interfaces;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQueryHandler : IRequestHandler<GetCardSetsQuery, CardSetVm>
    {   
        private readonly IReaderzDbContext _context;
        private readonly IMapper _mapper;

        public GetCardSetsQueryHandler(IReaderzDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CardSetVm> Handle(GetCardSetsQuery request, CancellationToken cancellationToken)
        {
            //ToDO
            return null;
        }
    }
}