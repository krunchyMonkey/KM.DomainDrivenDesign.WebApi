using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.ViewModel
{
    public class AccountsResponse<T>
    {
        public bool Success { get; set; }
        public int HttpResultCode { get; set; }
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
