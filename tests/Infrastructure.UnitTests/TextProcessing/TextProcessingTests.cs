using System;
using System.Collections.Generic;
using NUnit.Framework;
using Reader.Application.Common.Models;
using Readerz.Infrastructure.Services.TextProcessing;

namespace Infrastructure.UnitTests.TextProcessing
{
    public class TextProcessingTests
    {
        [Test]
        public void ShouldThrowsArgumentNullException()
        {
            var service = new TextProcessingService();
            Assert.Catch<ArgumentNullException>(() => service.Process(null));
        }
        
        [Test]
        public void ShouldReturnEmptyResultText()
        {
            var service = new TextProcessingService();
            var result = service.Process("");
            Assert.AreEqual("", result.Text);
        }

        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsCommonCase()
        {
            var service = new TextProcessingService();
            var result = service.Process("I love.");
            var expected = new TextProcessingResult(new List<TextItem>
            {
                new TextItem(true, "I"),
                new TextItem(false, " "),
                new TextItem(true, "love"),
                new TextItem(false, ".")
            });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsOnlyDelimiters()
        {
            var service = new TextProcessingService();
            var result = service.Process("./ ");
            var expected = new TextProcessingResult(new List<TextItem>
            {
                new TextItem(false, "./ ")
            });
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnCorrectResultText_WhenParametersIsOnlyLetters()
        {
            var service = new TextProcessingService();
            var result = service.Process("Lol");
            var expected = new TextProcessingResult(new List<TextItem>
            {
                new TextItem(true, "Lol")
            });
            
            Assert.AreEqual(expected, result);
        }
    }
}