using Accounts.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application
{
    [ExcludeFromCodeCoverage]
    public abstract class CommandHandler<T, U> : IRequestHandler<T, AccountsResponse<U>> where T :
                                                 IRequest<AccountsResponse<U>>
    {
        protected int _httpSuccessCode = 200;

        public abstract Task<AccountsResponse<U>> Handle(T request,
                                                              CancellationToken cancellationToken);

        protected AccountsResponse<U> CreateAccountsResponse(U response)
        {
            return new AccountsResponse<U>()
            {
                Success = true,
                HttpResultCode = _httpSuccessCode,
                Result = response
            };
        }
    }
}
