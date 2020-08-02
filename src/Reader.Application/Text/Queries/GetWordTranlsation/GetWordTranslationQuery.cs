using MediatR;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Text.Queries.GetWordTranlsation
{
    public class GetWordTranslationQuery : IRequest<TranslationResult>
    {
        public string Text { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public class GetWordTranslationQueryHandler : IRequestHandler<GetWordTranslationQuery, TranslationResult>
        {
            private readonly ITranslatiovService _translatiovService;
            public GetWordTranslationQueryHandler(ITranslatiovService service)
            {
                _translatiovService = service;
            }
            public async Task<TranslationResult> Handle(GetWordTranslationQuery request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(request.From))
                {
                    request.From = "auto";
                }

                return await _translatiovService.Translate(request.Text, request.To, request.From);
            }
        }
    }
}
