﻿using Accounts.Application.ViewModel;
using AutoMapper;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Accounts.Application
{
    [ExcludeFromCodeCoverage]
    public abstract class CommandHandler<T, U> : IRequestHandler<T, AccountsResponse<U>> where T :
                                                 IRequest<AccountsResponse<U>>
    {
        protected int _httpSuccessCode = 200;
        protected readonly IMapper Mapper;

        public CommandHandler(IMapper mapper) 
        {
            Mapper = mapper;
        }

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
