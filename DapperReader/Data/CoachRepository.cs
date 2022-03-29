using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperReader.Entities;
using DapperReader.Interfaces;

namespace DapperReader.Data;

public class CoachRepository: ICoachRepository
{
    private readonly SqlConnection _sqlConnection;

    private readonly IDbTransaction _dbTransaction;

    public CoachRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
        _sqlConnection = sqlConnection;
    }

    public async Task<IEnumerable<Coach>> GetCoachesAsync()
    {
        var sql = "SELECT * FROM Coaches";
        return await _sqlConnection.QueryAsync<Coach>(sql, null, _dbTransaction);
    }

    public async Task<Coach> GetCoachAsync(int id)
    {
        var sql = "SELECT * FROM Coaches WHERE Id=@id";
        return await _sqlConnection.QueryFirstOrDefaultAsync<Coach>(sql, new { id }, _dbTransaction);
    }
}