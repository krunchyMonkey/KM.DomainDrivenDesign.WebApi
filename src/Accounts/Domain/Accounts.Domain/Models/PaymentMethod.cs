using Accounts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Models
{
    public class PaymentMethod : IEntity
    {
        public Guid Id { get; set; }
        public string? PaymentType { get; set; }
        public string? AccountNumber { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Cvv { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string? RoutingNumber { get; set; }
    }
}
