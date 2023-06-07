using System;

namespace Application
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message) { }
    }
}
