using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;

namespace Reader.Application.Text.Queries.GetWordTranslation
{
    public class GetWordTranslationQuery : IRequest<TranslationResult>
    {
        public string Text { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
    
    public class GetWordTranslationQueryHandler : IRequestHandler<GetWordTranslationQuery, TranslationResult>
    {
        private readonly ITranslationService _translationService;
        public GetWordTranslationQueryHandler(ITranslationService service)
        {
            _translationService = service;
        }
        public async Task<TranslationResult> Handle(GetWordTranslationQuery request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.From))
            {
                request.From = "Auto";
            }

            return await _translationService.Translate(request.Text, request.To, request.From);
        }
    }
}
