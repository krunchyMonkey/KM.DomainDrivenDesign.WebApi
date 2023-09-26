using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.ViewModel.Requests
{
    public class CreateAccountRequest
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public string? AccountType { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Region { get; set; }
        [Required]
        public string? PostalCode { get; set; }
    }
}
