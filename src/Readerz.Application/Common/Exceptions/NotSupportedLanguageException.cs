using System;

namespace Readerz.Application.Common.Exceptions
{
    /// <summary>
    /// Represents an exception type that the language ISO isn't supported. 
    /// </summary>
    public class NotSupportedLanguageException : Exception
    {
        /// <summary>
        /// Instances a new not supported language exception object.
        /// </summary>
        /// <param name="languageIso">Language ISO that not supported.</param>
        public NotSupportedLanguageException(string languageIso)
            : base($"Language with ISO: {languageIso} is not supported, see https://cloud.google.com/translate/docs/languages")
        {
        }
    }
}
