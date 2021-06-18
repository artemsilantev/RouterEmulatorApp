using System;

namespace IPv6Library.Exceptions
{
    public class Ipv6FormatException: FormatException
    {
        private string _address;

        public Ipv6FormatException(string message, string address) : base(message)
        {
            _address = address;
        }

        
        public override string ToString()
        {
            return $"Problem with address format ({_address}){Message}";
        }
    }
}