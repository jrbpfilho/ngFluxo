using System.Threading.Tasks;
using System;

namespace ngFluxo.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}