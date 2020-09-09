using Readerz.Application.Common.Models;

namespace Readerz.Application.Common.Interfaces
{
    public interface ITextProcessingService
    {
        public TextProcessingResult Process(string text);
    }
}