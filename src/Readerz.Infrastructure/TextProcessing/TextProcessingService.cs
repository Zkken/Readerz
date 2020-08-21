using System;
using System.Text;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;

namespace Readerz.Infrastructure.TextProcessing
{
    public class TextProcessingService : ITextProcessingService
    {
        private const string PossibleDelimiters = "/\\,. \"{}[]();?!><”";
        
        public TextProcessingResult Process(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            
            var result = new TextProcessingResult();
            var chunkForLetters = new StringBuilder();
            var chunkForDelimiters = new StringBuilder();
            
            var lastSymbolIsDelimiter = false;
            var firstNoDelimiterSymbolHasAppeared = false;
            
            for(var i = 0; i < text.Length; i++)
            {
                if (PossibleDelimiters.Contains(text[i]))
                {
                    chunkForDelimiters.Append(text[i]);
                    
                    if (firstNoDelimiterSymbolHasAppeared)
                    {
                        result.Text.Add(new TextItem(true, chunkForLetters.ToString()));
                        chunkForLetters.Clear();
                    }

                    lastSymbolIsDelimiter = true;
                }
                else
                {
                    chunkForLetters.Append(text[i]);
                    
                    if (lastSymbolIsDelimiter)
                    {
                        result.Text.Add(new TextItem(false, chunkForDelimiters.ToString()));
                        chunkForDelimiters.Clear();
                    }

                    firstNoDelimiterSymbolHasAppeared = true;
                    lastSymbolIsDelimiter = false;
                }
                
                if (i == text.Length - 1)
                {
                    result.Text.Add(chunkForLetters.Length != 0
                        ? new TextItem(true, chunkForLetters.ToString())
                        : new TextItem(false, chunkForDelimiters.ToString()));
                }
            }
            
            return result;
        }
    }
}