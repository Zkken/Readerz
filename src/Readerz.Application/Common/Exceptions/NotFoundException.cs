using System;

namespace Readerz.Application.Common.Exceptions
{
    /// <summary>
    /// Represents an exception type that the requested entity wasn't found. 
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Instances a new not found exception object.
        /// </summary>
        /// <param name="name">The requested property name which value that couldn't be found.</param>
        /// <param name="key">Type that couldn't be found.</param>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {

        }
    }
}
