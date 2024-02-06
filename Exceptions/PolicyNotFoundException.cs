﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Exceptions
{
    internal class PolicyNotFoundException:ApplicationException
    {
        public PolicyNotFoundException() { }
        public PolicyNotFoundException(string message) : base(message)
        {

        }
    }
}
