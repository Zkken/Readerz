using System.Collections.Generic;

namespace Readerz.Application.Common.Models
{
    public class TranslationResult
    {
        /// <summary>
        /// Possible translations.
        /// </summary>
        public IEnumerable<string> Translations { get; set; }
    }
}
