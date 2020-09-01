using Reader.Application.Common.Models;

namespace Reader.Application.Common.Interfaces
{
    public interface ITextProcessingService
    {
        public TextProcessingResult Process(string text);
    }
}