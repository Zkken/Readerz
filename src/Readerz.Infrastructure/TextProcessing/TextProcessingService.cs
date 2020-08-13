using System;
using System.Text;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;

namespace Readerz.Infrastructure.TextProcessing
{
    public class TextProcessingService : ITextProcessingService
    {
        private const string PossibleDelimiters = "/\\,. \"{}[]();?!><";

        private enum Tag
        {
            Closed, Opened
        }
        
        public TextProcessingResult Process(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            
            var result = new TextProcessingResult();
            var chunk = new StringBuilder();

            var lastSymbolIsDelimiter = false;
            var firstNoDelimiterSymbol = false;
            
            foreach (var symbol in text)
            {
                if (PossibleDelimiters.Contains(symbol))
                {
                    if (lastSymbolIsDelimiter)
                    {
                        chunk.Append(symbol);
                        continue;
                    }

                    if (firstNoDelimiterSymbol)
                    {
                        chunk.Append(result.CloseTagIdentifier);
                    }
                    
                    lastSymbolIsDelimiter = true;
                }
                else
                {
                    if (lastSymbolIsDelimiter || !firstNoDelimiterSymbol)
                    {
                        chunk.Append(result.OpenTagIdetifier);
                    }
                    
                    firstNoDelimiterSymbol = true;
                    lastSymbolIsDelimiter = false;
                }
                
                chunk.Append(symbol);
            }

            result.Text = chunk.ToString();
            
            return result;
        }
    }
}