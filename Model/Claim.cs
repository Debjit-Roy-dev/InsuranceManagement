using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Claim
    {
        public int ClaimId{ get; set; }
        public int ClaimNumber { get; set; }

        public DateTime DateField { get; set; }
        public double ClaimAmount { get; set; }

        public string Status{ get; set;}
        public Policy Policyname { get; set;}
        public Client Clientname { get; set;}

        public Claim() { }

        public Claim(int claimId, int claimNumber, DateTime dateField, double claimAmount, string status, Policy policyname, Client clientname)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateField = dateField;
            ClaimAmount = claimAmount;
            Status = status;
            Policyname = policyname;
            Clientname = clientname;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Claim Id:{ClaimId}\tClaim Number:{ClaimNumber}\tClaimDate:{DateField}\tClaim Amount:Rs.{ClaimAmount}\t" +
                $"Policy Name:{Policyname.PolicyName}\tClient Name:{Clientname.ClientName}\n\n ");
        }
    }
}
