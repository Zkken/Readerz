using System;
using System.Collections.Generic;
using System.Linq;

namespace Readerz.Application.Common.Models
{
    public class WordsResult
    {
        public WordsResult()
        {
            Words = new List<WordItem>();
        }
        
        public WordsResult(List<WordItem> items)
        {
            Words = items;
        }

        public List<WordItem> Words { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is WordsResult result))
            {
                return false;
            }

            if (Words.Count != result.Words.Count)
            {
                return false;
            }

            return !Words.Where((t, i) => !t.Equals(result.Words[i])).Any();
        }

        public override int GetHashCode()
        {
            return Words != null ? Words.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Join(",", Words);
        }
    }

    public readonly struct WordItem
    {
        public WordItem(bool isWord, string value)
        {
            IsWord = isWord;
            Value = value;
        }

        private bool IsWord { get; }
        private string Value { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is WordItem item))
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