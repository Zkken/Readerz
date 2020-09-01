using System;
using System.Collections.Generic;
using System.Linq;

namespace Reader.Application.CardSets.Commands.IncrementCardSetCommand.Models
{
    public class TextProcessingResult
    {
        public TextProcessingResult()
        {
            Text = new List<TextItem>();
        }

        public TextProcessingResult(IList<TextItem> items)
        {
            Text = items;
        }
        
        public IList<TextItem> Text { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is TextProcessingResult result))
            {
                return false;
            }

            if (Text.Count != result.Text.Count)
            {
                return false;
            }

            return !Text.Where((t, i) => !t.Equals(result.Text[i])).Any();
        }

        public override int GetHashCode()
        {
            return Text != null ? Text.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Join(",", Text);
        }
    }

    public readonly struct TextItem
    {
        public TextItem(bool isWord, string value)
        {
            IsWord = isWord;
            Value = value;
        }

        public bool IsWord { get; }
        public string Value { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is TextItem item))
            {
                return false;
            }

            if (item.IsWord != IsWord)
            {
                return false;
            }

            return item.Value == Value;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(IsWord, Value);
        }

        public override string ToString()
        {
            return $"[val:\"{Value}\", word:\"{IsWord}\"]";
        }
    }
}