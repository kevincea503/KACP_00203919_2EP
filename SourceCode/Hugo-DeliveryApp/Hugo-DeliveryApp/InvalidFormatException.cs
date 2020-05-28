using System;

namespace Hugo_DeliveryApp
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message) :
            base(message){}
    }
}