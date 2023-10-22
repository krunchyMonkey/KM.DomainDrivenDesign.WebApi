namespace Accounts.Application.ViewModel
{
    public class AccountsResponse<T>
    {
        public bool Success { get; set; }
        public int HttpResultCode { get; set; }
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
