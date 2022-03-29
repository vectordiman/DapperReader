using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperReader.Entities;
using DapperReader.Interfaces;

namespace DapperReader.Data;

public class CoachRepository : ICoachRepository
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
        var sql =
            @"select * from Coaches join CoachSports CS on Coaches.Id = CS.CoachesId join Sports S on S.Id = CS.SportsId";

        var coaches = await _sqlConnection.QueryAsync<Coach, Sport, Coach>(sql, (coach, sport) =>
        {
            coach.Sports ??= new List<Sport>();
            coach.Sports.Add(sport);
            return coach;
        }, null, _dbTransaction);

        var result = coaches.GroupBy(c => c.Id).Select(g =>
        {
            var groupedCoach = g.First();
            groupedCoach.Sports = g.Select(p => p.Sports!.Single()).ToList();
            return groupedCoach;
        });

        return result;
    }

    public async Task<Coach?> GetCoachAsync(int id)
    {
        var sql =
            @"select * from sportix.dbo.Coaches join CoachSports CS on Coaches.Id = CS.CoachesId join Sports S on S.Id = CS.SportsId where Coaches.Id = @id";

        var coaches = await _sqlConnection.QueryAsync<Coach, Sport, Coach>(sql, (coach, sport) =>
        {
            coach.Sports ??= new List<Sport>();
            coach.Sports.Add(sport);
            return coach;
        }, new { id }, _dbTransaction);

        var result = coaches
            .GroupBy(c => c.Id)
            .Select(g =>
            {
                var groupedCoach = g.First();
                groupedCoach.Sports = g.Select(p => p.Sports!.Single()).ToList();
                return groupedCoach;
            })
            .SingleOrDefault(c => c.Id == @id);

        return result;
    }
}