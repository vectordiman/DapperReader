using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperReader.Entities;
using DapperReader.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperReader.Controllers;

public class AthletesController: BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public AthletesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Athlete>>> GetAthletes()
    {
        var coaches = await _unitOfWork.AthleteRepository.GetAthletesAsync();
        return Ok(coaches.ToArray());
    }

    [HttpGet("{athleteId}", Name = "GetAthlete")]
    public async Task<ActionResult<Athlete>> GetAthlete(int athleteId)
    {
        var coach = await _unitOfWork.AthleteRepository.GetAthleteAsync(athleteId);
        return Ok(coach);
    }
}