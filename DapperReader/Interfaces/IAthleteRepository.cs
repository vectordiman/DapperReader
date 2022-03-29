using System.Collections.Generic;
using System.Threading.Tasks;
using DapperReader.Entities;

namespace DapperReader.Interfaces;

public interface IAthleteRepository
{
    Task<IEnumerable<Athlete>> GetAthletesAsync();
    
    Task<Athlete> GetAthleteAsync(int id);
}