using System.Threading.Tasks;

namespace dFenix.InfrastructureNetCore
{
    public interface IActionCommandDispacher
    {
        Task Send(object command);
    }
}
