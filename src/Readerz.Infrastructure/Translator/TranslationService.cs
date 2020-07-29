using GoogleTranslateFreeApi;
using Reader.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace Readerz.Infrastructure.Translator
{
    public class TranslationService : ITranslatiovService
    {
        private readonly ITranslator _translator;

        public TranslationService()
        {
            _translator = new GoogleTranslator();
        }

        public async Task<Reader.Application.Common.Interfaces.TranslationResult>
            Translate(string text, string to, string from = "Auto")
        {
            var langFrom = Language.Auto;
            var langTo = GoogleTranslator.GetLanguageByName(to);
            var result = await _translator.TranslateAsync(text, langFrom, langTo);
            var translation = result.TranslatedTextTranscription;

            return new Reader.Application.Common.Interfaces.TranslationResult
            {
                Translation = translation
            };
        }

        //todo get all possible languages values with reflection or mb similar func already exists
    }
}