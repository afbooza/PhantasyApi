using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhantasyApi.Models;

namespace PhantasyApi.Repositories
{
    public interface ILeagueRepository
    {
        Task<League> GetById(int id);
        Task<int> CreateLeague(string name);
        Task<IEnumerable<League>> GetLeagues();
    }
}
