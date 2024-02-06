﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagement.Repository;
using InsuranceManagement.Model;
namespace InsuranceManagement.Services
{
    internal class InsuranceManagementServiceImpl:IInsuranceManagementService

    {
        readonly IInsuranceManagement _insuranceManagement;
        public InsuranceManagementServiceImpl()
        {
            _insuranceManagement = new InsuranceManagementImpl();
        }
        public void CreatePolicy()
        {
            Console.WriteLine("Enter Policy Id:");
            int policyId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Policy Name:");
            string policyName = Console.ReadLine();
            Policy policy = new Policy(policyId,policyName);
            bool addpolicystatus = _insuranceManagement.CreatePolicy(policy);
            if (addpolicystatus)
            {
                Console.WriteLine("Policy Added.");
            }
            else { Console.WriteLine("Couldn't Add Policy"); }


        }
        public void GetPolicy()
        {
            Console.WriteLine("Enter Policy Id :");
            int policyId=Convert.ToInt32(Console.ReadLine());

            Policy policy=_insuranceManagement.GetPolicy(policyId);
            if(policy != null)
            {
                Console.WriteLine($"Policy Id:{policy.PolicyId}\tPolicy Name:{policy.PolicyName}");
            }
            
        }
        public void GetAllPolicies()
        {
            List<Policy> policies = _insuranceManagement.GetAllPolicies();
            if (policies != null)
            {
                Console.WriteLine("Getting Policies...\n");

                foreach ( Policy policy in policies)
                {
                    Console.WriteLine($"Policy Id:{policy.PolicyId}\tPolicy Name:{policy.PolicyName}.\n");
                }
            }
        }
        public void UpdatePolicy()
        {
            Console.WriteLine("Enter Id of Policy You want to update:");
            int policyId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Policy Name:");
            string policyName=Console.ReadLine();
            Policy policy=new Policy(policyId,policyName);
            bool updatePolicyStatus=_insuranceManagement.UpdatePolicy(policy); 
            if (updatePolicyStatus)
            {
                Console.WriteLine("Policy Updated.");
            }

        }
        public void DeletePolicy()
        {
            Console.WriteLine("Enter Id of Policy You want to delete:");
            int policyId = Convert.ToInt32(Console.ReadLine());

            bool deletePolicyStatus=_insuranceManagement.DeletePolicy(policyId) ;
            if (deletePolicyStatus)
            {
                Console.WriteLine("Policy Deleted.");
            }

        }
        public void GetClientsByPolicyName()
        {
            Console.WriteLine("Enter  Policy Name:");
            string policyName = Console.ReadLine();
            List<Client> clients = _insuranceManagement.GetClientByPolicyName(policyName);

            if(clients != null)
            {
                Console.WriteLine($"Listing Clients with policyname {policyName}...\n");
                foreach( Client client in clients)
                {
                    Console.WriteLine($"Client Id:{client.ClientId}\nClient Name:{client.ClientName}\nContact Info:{client.ContactInfo}\nPolicy Name:{client.Policyname.PolicyName}\n\n");
                }
            }
            
        }
    }
}
