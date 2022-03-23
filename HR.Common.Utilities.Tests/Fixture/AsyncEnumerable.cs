using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Utilities.Tests.Fixture
{
    public class AsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly IEnumerable<T> enumerable;

        public AsyncEnumerable(IEnumerable<T> enumerable)
        {
            this.enumerable = Ensure.Argument.NotNull(() => enumerable);
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new AsyncEnumerator(enumerable.GetEnumerator());
        }

        private struct AsyncEnumerator : IAsyncEnumerator<T>
        {
            private readonly IEnumerator<T> enumerator;
            public AsyncEnumerator(IEnumerator<T> enumerator) => this.enumerator = enumerator;

            public T Current => enumerator.Current;
            public ValueTask<bool> MoveNextAsync() => ValueTask.FromResult(enumerator.MoveNext());
            public ValueTask DisposeAsync() => ValueTask.CompletedTask;
        }
    }
}
