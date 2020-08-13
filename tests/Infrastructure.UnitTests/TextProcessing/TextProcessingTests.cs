using System;
using NUnit.Framework;
using Readerz.Infrastructure.TextProcessing;

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
        public void ShouldReturnProcessedText()
        {
            var service = new TextProcessingService();
            var result = service.Process("I love sushi.");
            var expected = string.Concat(
                result.OpenTagIdetifier,
                "I",
                result.CloseTagIdentifier,
                " ",
                result.OpenTagIdetifier,
                "love",
                result.CloseTagIdentifier,
                " ",
                result.OpenTagIdetifier,
                "sushi",
                result.CloseTagIdentifier,
                "."
            );
            Assert.AreEqual(expected, result.Text);
        }

        [Test]
        public void ShouldReturnWithoutTags()
        {
            var service = new TextProcessingService();
            var result = service.Process("./ ");
            var expected = "./ ";
            Assert.AreEqual(expected, result.Text);
        }

        [Test]
        public void ShouldReturnEmptyResultText()
        {
            var service = new TextProcessingService();
            var result = service.Process("");
            Assert.AreEqual("", result.Text);
        }
    }
}