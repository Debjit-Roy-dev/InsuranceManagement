using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Users
    {
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Users() { }
        public Users (int userId, string userName,string password,string role)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"User Id:{UserId}\tUser Name:{UserName}\tUser Password:{Password}\tRole:{Role}\n\n");
        }
    }
}
