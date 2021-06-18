using System.Linq;
using System.Text;

namespace IPv6Library.Core
{
    public class Ipv6Converter
    {
        private static Ipv6Converter _converter;

        private Ipv6Converter()
        {
        }

        public static Ipv6Converter Instance => _converter ?? (_converter = new Ipv6Converter());
        
        public string ToShortAddress(Ipv6 ipv6)
        {
            var address = ipv6.Address;
            var octets = address.Split(':');
            var maxValue = 0;
            var indexToReplace = -1;
            var currentValue = 0;

            for (var i = 0; i < octets.Length; i++)
            {
                if (octets[i] == "0000")
                {
                    if (indexToReplace == -1)
                        indexToReplace = i;
                    currentValue++;
                }
                else
                {
                    if (currentValue <= maxValue) continue;
                    indexToReplace = i - currentValue;
                    maxValue = currentValue;
                    currentValue = 0;
                    continue;
                }
                if (i==octets.Length-1 &&currentValue >= maxValue)
                    maxValue = currentValue;
            }

            var builder = new StringBuilder();
            for (var i = 0; i < octets.Length; i++)
            {
                var isZero = true;
                if (i >= indexToReplace && i <= indexToReplace + maxValue - 1)
                {
                    if (i == indexToReplace)
                        builder.Append("::");
                    continue;
                }

                if (octets[i] == "0000")
                    builder.Append("0");
                else
                    for (var index = 0; index < octets[i].Length; index++)
                    {
                        var symbol = octets[i][index];
                        if (isZero)
                        {
                            if(symbol=='0')
                                continue;
                            isZero = false;
                        }
                        builder.Append(symbol);
                    }

                if (i != octets.Length - 1)
                    builder.Append(':');
            }

            if (builder.ToString().Contains(":::"))
            {
                builder.Replace(":::","::");
            }
            return builder.ToString();
        }
        
    }
}