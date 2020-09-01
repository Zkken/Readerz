using System.Collections.Generic;
using Readerz.Web.Domain.Common;

namespace Readerz.Domain.Entities
{
    public class Text : AuditableEntity
    {
        public Text()
        {
            CardSets = new HashSet<CardSet>();
        }
        public int Id { get; set; }
        public int CardSetId { get; set; }
        public string Name { get; set; }
        public string InnerText { get; set; }
        public ICollection<CardSet> CardSets { get; set; }
    }
}
