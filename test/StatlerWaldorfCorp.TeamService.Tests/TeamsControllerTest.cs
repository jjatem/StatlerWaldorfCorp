using System;
using Xunit;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Controllers;
using System.Collections.Generic;
using StatlerWaldorfCorp.TeamService.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace StatlerWaldorfCorp.TeamService
{
    public class TeamsControllerTest
    {
        TeamsController controller;
        ITeamRepository repo;

        //forcing a build
        public TeamsControllerTest()
        {
            repo = new MemoryTeamRepository();
            controller = new TeamsController(repo);
            repo.AddTeam(new Team("One"));
            repo.AddTeam(new Team("Two"));
        }
        

        [Fact]
        public async void QueryTeamListReturnsCorrectTeams()
        {
            var teams = await controller.GetAllTeams();
        }

        [Fact]
        public async void QueryTeamListReturns2Teams()
        {
            var teams = await controller.GetAllTeams();
            
        }

        [Fact]
        public async void CreateTeamAddsTeamToList()
        {

            TeamsController controller = new TeamsController(repo);

            var teams = (IEnumerable<Team>)
               (await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sample");
            var result = await controller.CreateTeam(t);

            var newTeamsRaw = (IEnumerable<Team>)
                              (await controller.GetAllTeams() as ObjectResult).Value;

            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count + 1);
            var sampleTeam =
                newTeams.FirstOrDefault(
                           target => target.Name == "sample");
            Assert.NotNull(sampleTeam);

        }
    }
}
