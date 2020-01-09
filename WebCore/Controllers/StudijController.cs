using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebCore.Models;
using WebCore.SqlScripts;

namespace WebCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Studij")]
    public class StudijController : Controller
    {

        private readonly IConfiguration configuration;
        public StudijController(IConfiguration config)
        {
            this.configuration = config;
        }

        ScriptHelper reader = new ScriptHelper();

        // GET: api/Studij
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<StudijDto> studij = null;

            var sqlString = reader.Read("SqlScripts/Studij/GetAll.sql");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                studij = await connection.QueryAsync<StudijDto>(sqlString);
            }

            return Ok(studij);

        }

        [HttpGet("{StudijOznaka}")]
        public async Task<IActionResult> Get(string StudijOznaka)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<StudijDto> studij = null;

            var sqlString = reader.Read("SqlScripts/Studij/GetID.sql");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    studij = await connection.QueryAsync<StudijDto>(sqlString, new { StudijOznaka});
                }

                return Ok(studij);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }


    }
}