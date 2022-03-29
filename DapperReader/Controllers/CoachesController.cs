using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperReader.Entities;
using DapperReader.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperReader.Controllers;

public class CoachesController: BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public CoachesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
    {
        var coaches = await _unitOfWork.CoachRepository.GetCoachesAsync();
        return Ok(coaches.ToArray());
    }

    [HttpGet("{coachId}", Name = "GetCoach")]
    public async Task<ActionResult<Coach>> GetCoach(int coachId)
    {
        var coach = await _unitOfWork.CoachRepository.GetCoachAsync(coachId);
        return Ok(coach);
    }
}