using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PhantasyApi.Models;

namespace PhantasyApi.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {

        private readonly IConfiguration _config;
        public LeagueRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnection"));
            }
        }


        public async Task<League> GetById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT league_id Id, name FROM league WHERE league_id = @LeagueId";
                conn.Open();
                var result = await conn.QueryAsync<League>(sQuery, new { LeagueId = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<League>> GetLeagues()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT league_id Id, name FROM league";
                conn.Open();
                var result = await conn.QueryAsync<League>(sql); 
                return result;
                
            }
        }

        public async Task<int> CreateLeague(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"INSERT INTO league (name)
                                  VALUES (@LeagueName)";
                var result = await conn.QueryAsync<int>(sQuery, new { LeagueName = name });
                return result.FirstOrDefault();
            }
        }

        //public async Task<>
    }
}
