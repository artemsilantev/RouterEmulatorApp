using System;
using System.Text;
using System.Text.RegularExpressions;
using IPv6Library.Exceptions;

namespace IPv6Library.Core
{
    public class Ipv6Parser
    {
        private static Ipv6Parser _parser;

        private Ipv6Parser()
        {
        }

        public static Ipv6Parser Instance => _parser ?? (_parser = new Ipv6Parser());

        public Ipv6 Parse(string address, bool isShort = false)
            => isShort ? FromShortAddress(address) : FromLongAddress(address);

        public Ipv6 Parse(Ipv6 ipv6, int prefix)
            => FromPrefix(ipv6, prefix);
            
        public bool TryParse(string address, out Ipv6 ipv6, bool isShort = false)
        {
            try
            {
                ipv6 = isShort ? FromShortAddress(address) : FromLongAddress(address);
                return true;
            }
            catch (Exception e)
            {
                ipv6 = null;
                return false;
            }
        }

        public bool TryParse(Ipv6 ipv6, int prefix, out Ipv6 ipv6Out)
        {
            try
            {
               ipv6Out = FromPrefix(ipv6, prefix);
               return true;
            }
            catch (Exception e)
            {
                ipv6Out = null;
                return false;
            }
        }

        private Ipv6 FromPrefix(Ipv6 ipv6, int prefix)
        {
            if (prefix % 4 != 0)
            {
                throw new Ipv6FormatException("Prefix must be divisible by 4 without a remainder", prefix.ToString());
            }

            var countToNull = prefix / 4;

            var hextet = ipv6.Address.Split(':');
            var builder = new StringBuilder();

            var isFinish = false;
            foreach (var octet in hextet)
            {
                foreach (var symbol in octet)
                {
                    countToNull--;
                    if (!isFinish)
                    {
                        
                        builder.Append(symbol);
                    }
                    else
                    {
                        builder.Append('0');
                        continue;
                    }
                    if (countToNull <=0)
                    {
                        isFinish = true;
                    }
                }
                builder.Append(':');
            }

            builder.Remove(builder.Length - 1, 1);
            return new Ipv6(builder.ToString());
        }
        
        private Ipv6 FromLongAddress(string longAddress)
        {
            if (!Regex.IsMatch(longAddress.ToLower(), "^([0-9a-f]{4}[:]{1}){7}([0-9a-f]{4}){1}$"))
            {
                throw new Ipv6FormatException("", longAddress);
            }

            return new Ipv6(longAddress.ToLower());
        }

        private Ipv6 FromShortAddress(string shortAddress)
        {
            var builder = new StringBuilder();
            var octets = shortAddress.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            var indexOfReduction = shortAddress.IndexOf("::");

            if (indexOfReduction != -1)
                octets = new StringBuilder(
                        shortAddress.Remove(indexOfReduction, shortAddress.Length - indexOfReduction))
                    .Append(':')
                    .Insert(indexOfReduction+1, "0000:",  8 - octets.Length)
                    .Append(shortAddress.Remove(0, indexOfReduction + 2))
                    .ToString()
                    .Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var octet in octets)
                builder.Append('0', 4 - octet.Length)
                    .Append($"{octet}:");

            if (builder[0] == ':') builder.Remove(0, 1);
            if (builder[builder.Length - 1] == ':') builder.Remove(builder.Length - 1, 1);

            return FromLongAddress(builder.ToString());
        }
    }
}