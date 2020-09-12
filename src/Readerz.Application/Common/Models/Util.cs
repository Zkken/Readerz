using System;
using System.Text;
using System.Threading.Tasks;
using Readerz.Application.Common.Interfaces;

namespace Readerz.Application.Common.Models
{
    public static class Util
    {
        public static Task<WordsResult> FindWordsAsync(string text)
        {
            return Task.Run(() => new FindWordsProcessor().Process(text));
        }
    }

    public class FindWordsProcessor 
    {
        private const string PossibleDelimiters = "/\\,. \"{}[]();?!><”";

        private readonly StringBuilder _chunkForLetters;
        private readonly StringBuilder _chunkForDelimiters;
        private readonly WordsResult _result;

        public FindWordsProcessor()
        {
            _result = new WordsResult();
            _chunkForDelimiters = new StringBuilder();
            _chunkForLetters = new StringBuilder();
        }

        public WordsResult Process(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var lastSymbolIsDelimiter = false;
            var firstNoDelimiterSymbolHasAppeared = false;

            foreach (var symbol in text)
            {
                if (PossibleDelimiters.Contains(symbol))
                {
                    _chunkForDelimiters.Append(symbol);

                    if (firstNoDelimiterSymbolHasAppeared)
                    {
                        AddLetters();
                    }

                    lastSymbolIsDelimiter = true;
                }
                else
                {
                    _chunkForLetters.Append(symbol);

                    if (lastSymbolIsDelimiter)
                    {
                        AddDelimiters();
                    }

                    firstNoDelimiterSymbolHasAppeared = true;
                    lastSymbolIsDelimiter = false;
                }
            }

            if (_chunkForLetters.Length != 0)
            {
                AddLetters();
            }
            else
            {
                AddDelimiters();
            }

            return _result;
        }

        private void AddLetters()
        {
            _result.Words.Add(new WordItem(true, _chunkForLetters.ToString()));
            _chunkForLetters.Clear();
        }

        private void AddDelimiters()
        {
            _result.Words.Add(new WordItem(false, _chunkForDelimiters.ToString()));
            _chunkForDelimiters.Clear();
        }
    }
}