using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTranslateFreeApi;
using Readerz.Application.Common.Exceptions;
using Readerz.Application.Common.Interfaces;
using Language = Readerz.Application.Common.Models.Language;
using Lang = GoogleTranslateFreeApi.Language;
using TranslationResult = Readerz.Application.Common.Models.TranslationResult;

namespace Readerz.Infrastructure.Services.Translator
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslator _translator;
        private IEnumerable<Language> _supportedLanguages;

        public TranslationService()
        {
            _translator = new GoogleTranslator();
        }

        public IEnumerable<Language> SupportedLanguages
        {
            get
            {
                return _supportedLanguages ??= GoogleTranslator.LanguagesSupported.ToList()
                    .Select(language => new Language
                        {
                            Name = language.FullName,
                            Iso = language.ISO639
                        }
                    );
            }
        }


        public async Task<TranslationResult> TranslateAsync(string text, string to, string from = "")
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }
            
            var langFrom = from == string.Empty ? Lang.Auto : GoogleTranslator.GetLanguageByISO(from);
            var langTo = GoogleTranslator.GetLanguageByISO(to);
            var result = await _translator.TranslateAsync(text, langFrom, langTo);

            return new TranslationResult
            {
                Translations = result.FragmentedTranslation
            };
        }
    }
}