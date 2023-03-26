using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator.Abstractions.Models
{
    public class CustomRequestExceptionHandlerState<TResponse>
    {
        public bool Handled { get; private set; }

        public TResponse Response { get; private set; }

        public void SetHandled(TResponse response = default)
        {
            Handled = true;
            Response = response;
        }
    }
}
