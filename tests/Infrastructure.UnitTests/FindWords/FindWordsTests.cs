using System;
using System.Collections.Generic;
using NUnit.Framework;
using Readerz.Application.Common.Models;

namespace Infrastructure.UnitTests.TextProcessing
{
    public class FindWordsTests
    {
        [Test]
        public void ShouldThrowsArgumentNullException()
        {
            var service = new FindWordsProcessor();
            Assert.Catch<ArgumentNullException>(() => service.Process(null));
        }
        
        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsCommonCase()
        {
            var service = new FindWordsProcessor();
            var result = service.Process("I love.");
            var expected = new WordsResult(new List<WordItem>
            {
                new WordItem(true, "I"),
                new WordItem(false, " "),
                new WordItem(true, "love"),
                new WordItem(false, ".")
            });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsOnlyDelimiters()
        {
            var service = new FindWordsProcessor();
            var result = service.Process("./ ");
            var expected = new WordsResult(new List<WordItem>
            {
                new WordItem(false, "./ ")
            });
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsOnlyLetters()
        {
            var service = new FindWordsProcessor();
            var result = service.Process("Lol");
            var expected = new WordsResult(new List<WordItem>
            {
                new WordItem(true, "Lol")
            });
            
            Assert.AreEqual(expected, result);
        }
    }
}