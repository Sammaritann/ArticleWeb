using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ArticleWeb.Services.Exceptions
{
    [Serializable]
    public class RequestedResourceException : Exception
    {
        public RequestedResourceException()
        {
        }

        public RequestedResourceException(string message)
            : base(message)
        {
        }

        public RequestedResourceException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected RequestedResourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
