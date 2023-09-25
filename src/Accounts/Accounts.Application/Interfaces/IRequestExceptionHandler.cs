using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Interfaces
{
    public interface IRequestExceptionHandler<in TRequest, TResponse, in TException>
        where TRequest : notnull
        where TException : Exception
    {
        Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken);
    }
}
