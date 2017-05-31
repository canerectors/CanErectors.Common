using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CanErectors.Common.Tests
{
    public class TypeExtensionTests
    {
        [Fact]
        public void GenericTypeFullNameShouldBePretty()
        {
            var genericType = typeof(IEnumerable<>).MakeGenericType(typeof(string));

            var prettyName = genericType.PrettyTypeName();

            Assert.Equal(prettyName, "System.Collections.Generic.IEnumerable<System.String>");
        }

        [Fact]
        public void GenericTypeShortNameShouldBePretty()
        {
            var genericType = typeof(IEnumerable<>).MakeGenericType(typeof(string));

            var prettyName = genericType.PrettyTypeName(false);

            Assert.Equal(prettyName, "IEnumerable<String>");
        }
    }
}
