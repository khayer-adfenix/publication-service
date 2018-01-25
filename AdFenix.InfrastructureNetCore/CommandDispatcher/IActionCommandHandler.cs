using System.Threading.Tasks;

namespace dFenix.InfrastructureNetCore
{
    public interface IActionCommandHandler<in TActionCommand>
    {
        Task Handle(TActionCommand command);
    }
}
