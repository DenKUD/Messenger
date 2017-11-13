using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.Model;
using System.Text;

namespace Messenger.AdditionalTests
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void ShouldCheckIfThoMessagesAreEqual()
        {
            // arrange
            Message originalMessage = new Message { Id = Guid.NewGuid(), Text="text",Body= Encoding.UTF8.GetBytes("body") };

            Message copyMessage = new Message {Id=originalMessage.Id,Text=originalMessage.Text,Body=originalMessage.Body };
            //act
            //assert
            Assert.IsTrue(originalMessage.Equals(copyMessage));
        }
    }
}
