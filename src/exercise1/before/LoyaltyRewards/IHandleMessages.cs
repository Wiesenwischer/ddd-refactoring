using System.Threading;
using System.Threading.Tasks;

namespace LoyaltyRewards
{
    public interface IHandleMessages<T>
    {
        public Task Handle(T message, CancellationToken cancellationToken);
    }
}
