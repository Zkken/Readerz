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


        public async Task<TranslationResult> Translate(string text, string to, string from = "auto")
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (SupportedLanguages.All(l => l.Iso != to))
            {
                throw new NotSupportedLanguageException(to);
            }

            if (from != "auto" && SupportedLanguages.All(l => l.Iso != from))
            {
                throw new NotSupportedLanguageException(to);
            }

            var langFrom = from == "auto" ? Lang.Auto : GoogleTranslator.GetLanguageByISO(from);
            var langTo = GoogleTranslator.GetLanguageByISO(to);
            var result = await _translator.TranslateAsync(text, langFrom, langTo);

            return new TranslationResult
            {
                Translations = result.FragmentedTranslation
            };
        }
    }
}