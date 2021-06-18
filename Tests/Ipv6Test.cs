using System;
using IPv6Library.Core;
using Xunit;
// ReSharper disable StringLiteralTypo

namespace Tests
{
    public class Ipv6Test
    {
        [Fact]
        public void shortParseTest1()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("FF80::123:1234:ABCD:EF12", true);
            Assert.Equal("FF80:0000:0000:0000:0123:1234:ABCD:EF12".ToLower(), ipv6.Address ); 
        }
        [Fact]
        public void shortParseTest2()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("FF02::1:FF00:300", true);
            Assert.Equal("FF02:0000:0000:0000:0000:0001:FF00:0300".ToLower(), ipv6.Address ); 
        }
        [Fact]
        public void shortParseTest3()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("::1", true);
            Assert.Equal("0000:0000:0000:0000:0000:0000:0000:0001".ToLower(), ipv6.Address ); 
        }
        [Fact]
        public void shortParseTest4()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("::", true);
            Assert.Equal("0000:0000:0000:0000:0000:0000:0000:0000".ToLower(), ipv6.Address ); 
        }

        
        [Fact]
        public void AddressToShortTest1()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("FF80:0000:0000:0000:0123:1234:ABCD:EF12");
            var shortAddress = Ipv6Converter.Instance.ToShortAddress(ipv6);
            Assert.Equal("FF80::123:1234:ABCD:EF12".ToLower(),shortAddress);
        }
        
        [Fact]
        public void AddressToShortTest2()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("FF02:0000:0000:0000:0000:0001:FF00:0300");
            var shortAddress = Ipv6Converter.Instance.ToShortAddress(ipv6);
            Assert.Equal("FF02::1:FF00:300".ToLower(),shortAddress);
        }
        [Fact]
        public void AddressToShortTest3()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("0000:0000:0000:0000:0000:0000:0000:0001");
            var shortAddress = Ipv6Converter.Instance.ToShortAddress(ipv6);
            Assert.Equal("::1",shortAddress);
        }
        [Fact]
        public void AddressToShortTest4()
        {
            var ipv6 = Ipv6Parser.Instance.Parse("0000:0000:0000:0000:0000:0000:0000:0000");
            var shortAddress = Ipv6Converter.Instance.ToShortAddress(ipv6);
            Assert.Equal("::",shortAddress);
        }
        
    }
}