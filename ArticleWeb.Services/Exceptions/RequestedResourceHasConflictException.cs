﻿using System;
using System.Runtime.Serialization;

namespace ArticleWeb.Services.Exceptions
{
    [Serializable]
    public class RequestedResourceHasConflictException : RequestedResourceException
    {
        public RequestedResourceHasConflictException()
        {
        }

        public RequestedResourceHasConflictException(string message)
            : base(message)
        {
        }

        public RequestedResourceHasConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected RequestedResourceHasConflictException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}