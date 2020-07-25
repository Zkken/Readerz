using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.CardSets.Queries.GetCardSets;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Queries.GetCardSetsByText
{
    public class GetCardSetByTextQuery : IRequest<CardSetVm>
    {
        public int TextId { get; set; }

        public class GetCardSetByTextQueryHandler : IRequestHandler<GetCardSetByTextQuery, CardSetVm>
        {
            private readonly IReaderzDbContext _context;
            private readonly IMapper _mapper;

            public GetCardSetByTextQueryHandler(IReaderzDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CardSetVm> Handle(GetCardSetByTextQuery request, CancellationToken cancellationToken)
            {
                var text = await _context.Texts
                    .Include(t => t.CardSets)
                    .FirstOrDefaultAsync(t => t.Id == request.TextId, cancellationToken);

                if (text == null)
                {
                    throw new NotFoundException(nameof(Text), request.TextId);
                }

                return new CardSetVm
                {
                    CardSetDtos = _mapper.Map<ICollection<CardSet>, ICollection<CardSetDto>>(text.CardSets)
                };
            }
        }
    }
}