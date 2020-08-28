using GoogleTranslateFreeApi;
using Reader.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Language = Reader.Application.Common.Models.Language;
using Lang = GoogleTranslateFreeApi.Language;
using TranslationResult = Reader.Application.Common.Models.TranslationResult;
using TranslationRes = GoogleTranslateFreeApi.TranslationResult;
using System;
using Reader.Application.Common.Exceptions;

namespace Readerz.Infrastructure.Translator
{
    public class TranslationService : ITranslatiovService
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
                            ISO = language.ISO639
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

            if (SupportedLanguages.All(l => l.ISO != to))
            {
                throw new NotSupportedLanguageException(to);
            }

            if (from != "auto" && SupportedLanguages.All(l => l.ISO != from))
            {
                throw new NotSupportedLanguageException(to);
            }

            var langFrom = from == "auto" ? Lang.Auto : GoogleTranslator.GetLanguageByISO(from);
            var langTo = GoogleTranslator.GetLanguageByISO(to);
            var result = await _translator.TranslateAsync(text, langFrom, langTo);

            return new TranslationResult
            {
                Translations = result.FragmentedTranslation.Concat(result.SeeAlso)
            };
        }
    }
}