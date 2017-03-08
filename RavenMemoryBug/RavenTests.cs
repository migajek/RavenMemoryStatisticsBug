using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Raven.Database.Config;
using Xunit;

namespace RavenMemoryBug
{
    public class Foo
    {
    }

    public class RavenTests
    {       
        [Fact]
        public async Task ThisWillFail()
        {
            CallContext.LogicalSetData("ABC", new Foo());
            var mem = MemoryStatistics.AvailableMemoryInMb;
            CallContext.LogicalSetData("ABC", null);
        }
    }
}