using System;
using Moq;
using NUnit.Framework;

namespace ExtractClass.UnitTests
{
    [TestFixture]
    public class ExtractClassTests
    {
        private Person _sender;
        private Person _receiver;
        private string _subject;
        private string _text;

        private Mock<IEmailSend> _emailSend;
        private PersonLists _personLists;

        [SetUp]
        public void SetUp()
        {
            _sender = new Person("p1", 1)
            {
                Email = new Email("a", "b", "c")
            };
            _receiver = new Person("p2", 2)
            {
                Email = new Email("d", "e", "f")
            };
            _subject = "subject";
            _text = "text";

            _emailSend = new Mock<IEmailSend>();
            _emailSend.Setup(es => es.Send(_sender.Email, _receiver.Email.Address, _subject, _text))
                .Returns(true);

            _personLists = new PersonLists(_emailSend.Object);
        }

        [Test]
        public void SendMessage_WhenCalled_VerifyPassingThrough()
        {
            _personLists.SendMessage(_sender, _receiver, _subject, _text);

            _emailSend.Verify(es => es.Send(_sender.Email, _receiver.Email.Address, _subject, _text));
        }
    }
}
