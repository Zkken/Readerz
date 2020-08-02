using System;
using System.Collections.Generic;
using System.Text;

namespace Reader.Application.Common.Exceptions
{
    public class NotSupportedLanguageException : Exception
    {
        public NotSupportedLanguageException(string languageISO)
            : base($"Language with ISO: {languageISO} is not supported, see https://cloud.google.com/translate/docs/languages")
        {

        }
    }
}
