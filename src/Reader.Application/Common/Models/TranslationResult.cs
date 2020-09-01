using System.Collections.Generic;

namespace Reader.Application.CardSets.Commands.IncrementCardSetCommand.Models
{
    public class TranslationResult
    {
        /// <summary>
        /// Possible translations.
        /// </summary>
        public IEnumerable<string> Translations { get; set; }
    }
}
