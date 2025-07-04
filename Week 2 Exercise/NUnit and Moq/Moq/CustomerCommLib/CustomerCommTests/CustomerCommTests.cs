using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mailSenderMock = new Mock<IMailSender>();

            _mailSenderMock
                .Setup(ms => ms.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mailSenderMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            var result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);

            _mailSenderMock.Verify(ms => ms.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
