using System.Collections.Generic;

namespace Readerz.Domain.Entities
{
    public class CardCreator
    {
        public CardCreator()
        {
            CardSets = new HashSet<CardSet>();
        }
        
        public int CardCreatorId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
        public string UserId { get; set; }
        
        public ICollection<CardSet> CardSets { get; private set; }
    }
}
