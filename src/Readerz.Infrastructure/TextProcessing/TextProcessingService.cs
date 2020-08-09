using System.Text;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;

namespace Readerz.Infrastructure.TextProcessing
{
    public class TextProcessingService : ITextProcessingService
    {
        private const string PossibleDelimiters = "/\\,. \"{}[]();?!><";

        public TextProcessingResult Process(string text)
        {
            var result = new TextProcessingResult();
            var chunk = new StringBuilder(result.UniqueIdentifier);

            foreach (var t in text)
            {
                if (PossibleDelimiters.Contains(t))
                {
                    chunk.Append(result.UniqueIdentifier);
                }

                chunk.Append(t);
            }

            result.Text = chunk.ToString();
            
            return result;
        }
    }
}