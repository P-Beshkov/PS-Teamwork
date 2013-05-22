using System;

namespace Logic
{
    public class TypeFoodException : Exception
    {
        public TypeFoodException()
        {
        }

        public TypeFoodException(string message) : base(message)
        {
        }

        public TypeFoodException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TypeFoodException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}