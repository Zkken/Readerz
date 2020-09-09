using System.Collections.Generic;
using System.Threading.Tasks;
using Readerz.Application.Common.Models;

namespace Readerz.Application.Common.Interfaces
{
    /// <summary>
    /// Service defines text translations functionality.
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Translates text from one language to another.
        /// </summary>
        /// <param name="text">The actual text.</param>
        /// <param name="to">To what language. Must be represented as language ISO.</param>
        /// <param name="from">From which language. Must be represented as language ISO.
        /// The "Auto" value means that the translator will automatically define the Language ISO.
        /// </param>
        /// <returns></returns>
        Task<TranslationResult> Translate(string text, string to, string from = "Auto");
        
        /// <summary>
        /// Languages supported by the Translator.
        /// </summary>
        IEnumerable<Language> SupportedLanguages { get; } 
    }
}
