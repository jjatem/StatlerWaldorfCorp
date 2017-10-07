using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.TeamService.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        ITeamRepository repository;

        public TeamsController(ITeamRepository repo)
        {
            repo.AddTeam(new Team("One"));
            repo.AddTeam(new Team("Two"));
            repository = repo;
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetAllTeams()
        {
            return this.Ok(repository.GetTeams());
        }

        [HttpPost]
        public async virtual Task<IActionResult> CreateTeam([FromBody]Team newTeam)
        {
             this.repository.AddTeam(newTeam);

             return this.Created($"/teams/{newTeam.ID}", newTeam);
        }


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
