using System.Collections.Generic;
using System.Threading.Tasks;
using DapperReader.Entities;

namespace DapperReader.Interfaces;

public interface ICoachRepository
{
    Task<IEnumerable<Coach>> GetCoachesAsync();
    
    Task<Coach> GetCoachAsync(int id);
}