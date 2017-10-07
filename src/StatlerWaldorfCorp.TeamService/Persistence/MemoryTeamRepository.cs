using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            if (teams == null){
                teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> Teams)
        {
            teams = Teams;
        }

        public void AddTeam(Team t)
        {
            teams.Add(t);
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }
    }
}
