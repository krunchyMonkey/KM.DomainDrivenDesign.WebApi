using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? AccountType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public List<PaymentMethod>? PaymentMethods { get; set; }
        public List<Person>? People { get; set; }
    }
}
