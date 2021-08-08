using System;
using System.Data;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
        IDbConnection Connection { get; }

    }
}
