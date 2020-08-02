using System.Collections.Generic;

namespace Reader.Application.Common.Models
{
    public class TranslationResult
    {
        /// <summary>
        /// Possible translations
        /// </summary>
        public IEnumerable<string> Translations { get; set; }
    }
}
