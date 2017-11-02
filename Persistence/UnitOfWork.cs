using System.Threading.Tasks;
using ngFluxo.Core;

namespace ngFluxo.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluxoDeCaixaDAO context;

        public UnitOfWork(FluxoDeCaixaDAO context)
        {
        this.context = context;
        }

        public async Task CompleteAsync()
        {
        await context.SaveChangesAsync();
        }
    }
}