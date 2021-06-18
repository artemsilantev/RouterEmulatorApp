using System;
using System.Text;
using System.Text.RegularExpressions;
using IPv6Library.Exceptions;

namespace IPv6Library.Core
{
    public class Ipv6
    {
        private readonly string _address; 
        public string Address { get=>_address; }
        
        public Ipv6()
        {
            _address = "";
        }

        internal Ipv6(string address)
        {
           _address = address;
        }

        public override string ToString()
        {
            return $"{_address}";
        }
    }
}