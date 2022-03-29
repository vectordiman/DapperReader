using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperReader.Entities;
using DapperReader.Interfaces;

namespace DapperReader.Data;

public class AthleteRepository: IAthleteRepository
{
    private readonly SqlConnection _sqlConnection;

    private readonly IDbTransaction _dbTransaction;

    public AthleteRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
        _sqlConnection = sqlConnection;
    }
    
    public async Task<IEnumerable<Athlete>> GetAthletesAsync()
    {
        var sql = "SELECT * FROM [sportix].dbo.Athletes";
        return await _sqlConnection.QueryAsync<Athlete>(sql, null, _dbTransaction);
    }

    public async Task<Athlete> GetAthleteAsync(int id)
    {
        var sql = "SELECT * FROM [sportix].dbo.Athletes WHERE Id=@id";
        return await _sqlConnection.QueryFirstOrDefaultAsync<Athlete>(sql, new { id }, _dbTransaction);
    }
}