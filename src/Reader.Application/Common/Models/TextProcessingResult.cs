using System;
using System.Collections.Generic;

namespace Reader.Application.Common.Models
{
    public class TextProcessingResult
    {
        public TextProcessingResult()
        {
            UniqueIdentifier = Guid.NewGuid().ToString().Split('-')[0];
        }
        
        public string UniqueIdentifier { get; }
        public string Text { get; set; }
    }
}