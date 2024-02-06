using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }

        public double PaymentAmount { get; set; }
        public Client Clientname { get; set; }

        public Payment() { }
        public Payment(int paymentId, DateTime paymentDate, double paymentAmount, Client clientname)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            Clientname = clientname;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Payment Id:{PaymentId}\tPayment Date:{PaymentDate}\tPayment Amount:Rs.{PaymentAmount}\t Client Name:{Clientname.ClientName}.\n\n");
        }
    }
}
