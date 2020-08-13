using System;
using System.Collections.Generic;

namespace Reader.Application.Common.Models
{
    public class TextProcessingResult
    {
        public TextProcessingResult()
        {
            UniqueIdentifier = Guid.NewGuid().ToString().Split('-')[0][..4];
            OpenTagIdetifier = Guid.NewGuid().ToString().Split('-')[0][..4];
            CloseTagIdentifier = Guid.NewGuid().ToString().Split('-')[0][..4];
        }
        
        public string OpenTagIdetifier { get; }
        public string CloseTagIdentifier { get;  }
        public string UniqueIdentifier { get; }
        public string Text { get; set; }
    }
}