using System.Threading.Tasks;
using kolos2pod2.Models;
using kolos2pod2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos2pod2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IDbService _dbService;

        public MainController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{TeamId}")]
        public async Task<IActionResult> GetTeam(int TeamID)
        {
            if (!await _dbService.CheckTeam(TeamID))
            {
                return NotFound("team doesn't exist");
            }

            var result = await _dbService.GetTeam(TeamID);
            return Ok(result);
        }

        [HttpPost("{MemberId}")]
        public async Task<IActionResult> AddMember(int MemberID)
        {
            if (!await _dbService.CheckMember(MemberID))
            {
                return NotFound("fail checkmember");
            }

            if (!await _dbService.CheckMember(MemberID))
                return BadRequest("fail checkmember");
            var result = await _dbService.AddMember(MemberID);
            return Ok(result);
        }

    }
}
