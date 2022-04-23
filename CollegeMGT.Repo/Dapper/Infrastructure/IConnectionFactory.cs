using System;
using System.Data;

namespace CollegeMGT.Repo.Dapper.Infrastructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
