using MediatR;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Text.Queries.GetSupportedLanguages
{
    public class LanguageVm
    {
        public IEnumerable<Language> Languages { get; set; }
    }

    public class GetSupportedLanguagesQuery : IRequest<LanguageVm>
    {
    }
    
    public class GetSupportedLanguagesQueryHandler : IRequestHandler<GetSupportedLanguagesQuery, LanguageVm>
    {
        private readonly ITranslationService _translationService;

        public GetSupportedLanguagesQueryHandler(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public async Task<LanguageVm> Handle(GetSupportedLanguagesQuery request, CancellationToken cancellationToken)
        {
            return new LanguageVm
            {
                Languages = await Task.Run(() => _translationService.SupportedLanguages, cancellationToken)
            };
        }
    }
}
