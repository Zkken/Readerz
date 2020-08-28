using System;

namespace Reader.Application.Common.Exceptions
{
    public class PaginatorException : Exception
    {
        public PaginatorException(string message) 
        : base(message)
        {
            
        }
    }
}