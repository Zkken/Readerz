using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Models;

namespace Reader.Application.CardSets.Commands.IncrementCardSetCommand.Interfaces
{
    public interface ITextProcessingService
    {
        public TextProcessingResult Process(string text);
    }
}