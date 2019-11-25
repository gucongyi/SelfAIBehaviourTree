
namespace FluentBehaviour
{
    using System;

    public class BehaviorException : Exception
    {
        public BehaviorException(string message)
            : base(message)
        { }
    }
}