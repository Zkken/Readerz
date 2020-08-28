using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reader.Application.Common.Interfaces;

namespace Reader.Application.CardSets.Queries.GetCardSetsByText
{
    public class GetCardSetByTextQuery : IRequest<object>
    {
        public int TextId { get; set; }

        public class GetCardSetByTextQueryHandler : IRequestHandler<GetCardSetByTextQuery, object>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCardSetByTextQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<object> Handle(GetCardSetByTextQuery request, CancellationToken cancellationToken)
            {
                // var text = await _context.Texts
                //     .Include(t => t.CardSets)
                //     .FirstOrDefaultAsync(t => t.Id == request.TextId, cancellationToken);
                //
                // if (text == null)
                // {
                //     throw new NotFoundException(nameof(Text), request.TextId);
                // }
                //
                // return new CardSetVm
                // {
                //     CardSets = _mapper.Map<ICollection<CardSet>, ICollection<CardSetDto>>(text.CardSets)
                // };
                
                throw new NotImplementedException();
            }
        }
    }
}