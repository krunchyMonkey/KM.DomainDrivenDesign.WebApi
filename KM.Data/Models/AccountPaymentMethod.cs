﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Models
{
    public class AccountPaymentMethod
    {
        public Guid AccountId { get; set; } 
        public Guid PaymentMethodId { get; set; }
    }
}
