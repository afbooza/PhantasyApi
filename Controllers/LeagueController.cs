using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhantasyApi.Models;
using PhantasyApi.Repositories;

namespace PhantasyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        private readonly ILeagueRepository _leagueRepo;

        public LeagueController(ILeagueRepository leagueRepo)
        {
            _leagueRepo = leagueRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<League>> GetByID(int id)
        {
            var response = await _leagueRepo.GetById(id);
            if(response == null)
            {
                return NotFound("No results found for league with the id of " + id);
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<League>> GetAllLeagues()
        {
            var response = await _leagueRepo.GetLeagues();
            if(response == null)
            {
                return NotFound("Empty results.");
            }

            return Ok(response);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> CreateLeague([FromBody] League league)
        {
            return await _leagueRepo.CreateLeague(league.Name);
        }

    }
}
