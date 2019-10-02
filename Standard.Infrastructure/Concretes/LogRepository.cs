using Microsoft.Extensions.Options;
using Standard.Framework.Data.Concretes;
using Standard.Framework.Data.Options;
using Standard.Infrastructure.Abstractions;
using Standard.Models.Entities;
using System.Threading.Tasks;

namespace Standard.Infrastructure.Concretes
{
    public class LogRepository : FirebaseRepository<Log>, ILogRepository
    {
        public LogRepository(IOptions<FirebaseClientOptions> clientOptions) : base(clientOptions) { }
        
        public async Task IncluirAsync(Log model)
        {
            //Não foi configurado o banco Firebase ou Sql Server. (Estou verificando a necessidade)

            //await base.InsertAsync(model);
        }
    }
}
