using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactInfo { get; set; }
        public Policy Policyname { get; set; }
        public Client() { }
        public Client(int ClientId,string ClientName,string ConcatInfo,Policy policyname)
        {
            ClientId = ClientId;
            ClientName = ClientName;
            ConcatInfo = ConcatInfo;
            Policyname = policyname;
        }

        public void ShowDetals()
        {
            Console.WriteLine($"Client Id:{ClientId}\tClient Name:{ClientName}\tContact Info:{ContactInfo}\tPolicy Name:{Policyname.PolicyName}\n\n ");
        }
    }
}
