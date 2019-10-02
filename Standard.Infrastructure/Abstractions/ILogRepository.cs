using Standard.Models.Entities;
using System.Threading.Tasks;

namespace Standard.Infrastructure.Abstractions
{
    public interface ILogRepository
    {
        Task IncluirAsync(Log model);
    }
}
