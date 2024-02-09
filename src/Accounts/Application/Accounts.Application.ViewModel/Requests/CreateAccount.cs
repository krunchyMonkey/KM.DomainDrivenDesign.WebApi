using System.ComponentModel.DataAnnotations;

namespace Accounts.Application.ViewModel.Requests
{
    public class CreateAccount
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
