using System;
using System.Threading.Tasks;

namespace HR.Common.Utilities.Tests.Fixture
{
    public class AsyncDisposable : IAsyncDisposable
    {
        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }
}
