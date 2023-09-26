using MediatR.Pipeline;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts.Infrastucture.ViewModel;
using System.Net;

namespace Accounts.Application
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseExceptionHandler<T, U, V, K> : IRequestExceptionHandler<T, U, V>
                                            where T : IRequest<U>
                                            where U : AccountsResponse<K>
                                            where V : Exception
    {
        private const string _errorMessagePrefix = "The following Error message has been thrown";
        private const string _defaultErrorMessage = "An error occured that is preventing transaction(s) from being returned.";

        private const int _httpUnauthorizedErrorCode = 401;
        private const int _httpInternalError = 500;

        private readonly ILogger<BaseExceptionHandler<T, U, V, K>> _logger;

        public BaseExceptionHandler(ILogger<BaseExceptionHandler<T, U, V, K>> logger)
        {
            _logger = logger;
        }

        public async Task Handle(T request, V exception, RequestExceptionHandlerState<U> state, CancellationToken cancellationToken)
        {
            var currentMaxErrorCode = 0;
            var currentErrorMessage = string.Empty;

            if (!state.Handled || state.Response == null)
            {
                state.SetHandled(CreateStateResult());
            }

            if (exception is AggregateException)
            {
                var aggregateException = exception as AggregateException;

                foreach (var exceptions in aggregateException?.InnerExceptions)
                {

                    ProccessErrorMessage(exceptions, ref state);

                    if (state.Response.HttpResultCode > currentMaxErrorCode)
                    {
                        currentMaxErrorCode = state.Response.HttpResultCode;
                        currentErrorMessage = state.Response.ErrorMessage;
                    }
                }

                state.Response.HttpResultCode = currentMaxErrorCode == 0 ? _httpInternalError : currentMaxErrorCode;
                state.Response.ErrorMessage = currentErrorMessage;
            }
            else
            {
                ProccessErrorMessage(exception, ref state);
            }
        }

        protected void ProccessErrorMessage(Exception exception, ref RequestExceptionHandlerState<U> state)
        {
            state.Response.Success = false;

            var errorMessage = string.Empty;
            string customErrorMessage = string.Empty;

            switch (exception)
            {
                case UnauthorizedAccessException uae:
                    errorMessage = $"{_errorMessagePrefix} : {uae.Message}.";
                    state.Response.HttpResultCode = _httpUnauthorizedErrorCode;
                    break;
                case NotImplementedException nix:
                    errorMessage = $"{_errorMessagePrefix} : {nix.Message}.";
                    state.Response.HttpResultCode = _httpInternalError;
                    break;
                case DbException dbex:
                    errorMessage = $"{_errorMessagePrefix} : {dbex.Message}.";
                    customErrorMessage = dbex.Message;
                    state.Response.HttpResultCode = (int)dbex.ErrorCode;
                    break;
                case ArgumentException arg:
                    errorMessage = $"{_errorMessagePrefix} : {arg.Message}.";
                    state.Response.HttpResultCode = (int)HttpStatusCode.Conflict;
                    customErrorMessage = errorMessage;
                    break;
                case Exception ex:
                    errorMessage = $"{_errorMessagePrefix} {ex.Message}.";
                    state.Response.HttpResultCode = _httpInternalError;
                    break;
            }

            _logger.LogError($"{errorMessage}.");
            state.Response.ErrorMessage = string.IsNullOrWhiteSpace(customErrorMessage) ? _defaultErrorMessage : customErrorMessage;


        }

        private U CreateStateResult()
        {
            return (U)Activator.CreateInstance(typeof(U));
        }
    }
}
