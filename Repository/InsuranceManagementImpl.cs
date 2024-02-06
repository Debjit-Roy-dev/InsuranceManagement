using InsuranceManagement.Model;
using InsuranceManagement.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagement.Exceptions;

namespace InsuranceManagement.Repository
{
    internal class InsuranceManagementImpl : IInsuranceManagement
    {
        public string connectionString ;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public InsuranceManagementImpl()
        {
            sqlconnection = new SqlConnection(DBConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool CreatePolicy(Policy policy)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Insert into Policy values(@policyID,@policyName)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);

                
                int addPolicyStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (addPolicyStatus > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public Policy GetPolicy(int policyId)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "select * from Policy where PolicyId= @policyId";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyId", policyId);
                Policy policy = new Policy();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        policy.PolicyId = (int)reader["policyId"];
                        policy.PolicyName= (string)reader["policyName"];
                        sqlconnection.Close();
                        return policy;
                    }
                    else
                    {
                        sqlconnection.Close();
                        
                        throw new PolicyNotFoundException("No Such Policy Found");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return null; 
            }
        }
        public List<Policy> GetAllPolicies()
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Select * from Policy";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                List<Policy> policies = new List<Policy>();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyId = (int)reader["policyId"];
                    policy.PolicyName = (string)reader["policyName"];
                    policies.Add(policy);
                    count++;
                }
                sqlconnection.Close();
                if (count == 0)
                {
                    throw new PolicyNotFoundException("No  Policy Found");
                }
                return policies;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool UpdatePolicy(Policy policy)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Update Policy set policyName=@policyName where policyId=@policyId";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);
                cmd.Parameters.AddWithValue("@policyId", policy.PolicyId);
                int updatePolicyStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if(updatePolicyStatus > 0) { return true; }
                else 
                {
                    throw new PolicyNotFoundException("No Such Policy Found");
                     
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeletePolicy(int policyId)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "delete from  Policy where policyId=@policyId";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                
                cmd.Parameters.AddWithValue("@policyId", policyId);
                int deletePolicyStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (deletePolicyStatus > 0) { return true; }
                else
                {
                    throw new PolicyNotFoundException("No Such Policy Found");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Extra Function Asked 
        public List<Client> GetClientByPolicyName(string policyName)
        {
            try
            {
                sqlconnection.Open();
                cmd.CommandText = "Select * from Client join Policy on Client.policyId = Policy.policyId where Policy.policyname=@policyName";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyName", policyName);
                List<Client> clients = new List<Client>();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    Client client = new Client();
                    policy.PolicyId = (int)reader["policyId"];
                    policy.PolicyName = (string)reader["policyName"];
                    client.ClientId = (int)reader["ClientId"];
                    client.ClientName = (string)reader["ClientName"];
                    client.ContactInfo = (string)reader["ContactInfo"];
                    client.Policyname = policy;
                    clients.Add(client);
                    count++;
                }
                sqlconnection.Close();
                if (count == 0)
                {
                    throw new PolicyNotFoundException("No Such Policy Found");
                }
                return clients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
