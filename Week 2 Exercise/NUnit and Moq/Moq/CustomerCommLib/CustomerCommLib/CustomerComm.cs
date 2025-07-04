namespace CustomerCommLib
{
    public class CustomerComm
    {
        IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            string toAddress = "cust123@abc.com";
            string message = "Some Message";

            _mailSender.SendMail(toAddress, message);

            return true;
        }
    }
}
