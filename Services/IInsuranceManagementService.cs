using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Services
{
    internal interface IInsuranceManagementService
    {
        void CreatePolicy();
        void GetPolicy();
        void GetAllPolicies();
        void UpdatePolicy();
        void DeletePolicy();
        void GetClientsByPolicyName();
    }
}
