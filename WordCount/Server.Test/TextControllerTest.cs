using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Models;
using Server.Data;
using Server.Controllers;
using Server.Repositories;
using Server.Test.FakeRepositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;


namespace Server.Test
{
    [TestClass]
    public class TextControllerTest
    {
        [TestMethod]
        public void GetTextDataIdCheck()
        {
            ITextRepository repository = new FakeTextRepository();
            Mock<ILogger<TextController>> mockLogger = new Mock<ILogger<TextController>>();
            TextController textController = new TextController(repository, mockLogger.Object);
            var result = textController.Get();
            TextData text = result.Value;
            Assert.AreEqual(text.Id, 10);
        }

        [TestMethod]
        public void GetTextDataTypeCheck()
        {
            ITextRepository repository = new FakeTextRepository();
            Mock<ILogger<TextController>> mockLogger = new Mock<ILogger<TextController>>();
            TextController textController = new TextController(repository, mockLogger.Object);
            var result = textController.Get();
            TextData text = result.Value;
            Assert.AreEqual(text.GetType(), typeof(TextData));
        }

        [TestMethod]
        public void WordCountCheck()
        {
            string test = " This string has          5 words   ";
            ITextRepository repository = new FakeTextRepository();
            Mock<ILogger<TextController>> mockLogger = new Mock<ILogger<TextController>>();
            TextController textController = new TextController(repository, mockLogger.Object);
            var result = textController.WordCount(test);
            int wordNumber = result.Value;
            Assert.AreEqual(wordNumber, 5);
        }
    }
}
