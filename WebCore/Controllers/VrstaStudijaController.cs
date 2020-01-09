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
using System.Net.Http;
using System.IO;
using WebCore.SqlScripts;
using Microsoft.AspNetCore.Authorization;

namespace WebCore.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/VrstaStudija")]
    public class VrstaStudijaController : Controller
    {
        private readonly IConfiguration configuration;

        public VrstaStudijaController(IConfiguration config)
        {
            this.configuration = config;
        }

        ScriptHelper reader = new ScriptHelper();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<VrstaStudijaDto> studija = null;

            string sqlScript = reader.Read("SqlScripts/VrstaStudija/GetAll.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    studija = await connection.QueryAsync<VrstaStudijaDto>(sqlScript);

                }
                return Ok(studija);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

        }

        [HttpGet("{oznaka}")]
        public async Task<IActionResult> Get(string oznaka)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<VrstaStudijaDto> studija = null;
            string sqlString = reader.Read("SqlScripts/VrstaStudija/GetOznaka.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    studija = await connection.QueryAsync<VrstaStudijaDto>(sqlString, new { oznaka});
                }
                return Ok(studija);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpDelete("{oznaka}")]
        public async Task<IActionResult> Delete(string oznaka)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/VrstaStudija/DeleteOznaka.sql");
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.QueryAsync<VrstaStudijaDto>(sqlString, new { oznaka });
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VrstaStudijaDto vrstaStudija)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/VrstaStudija/Put.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlString, new { vrstaStudija.VrstaStudijaNaziv, vrstaStudija.VrstaStudijaRazina, vrstaStudija.TipStudijskogPrograma, vrstaStudija.VrstaStudijaOznaka });
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VrstaStudijaDto vrstaStudija)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/VrstaStudija/Post.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlString, new { vrstaStudija.VrstaStudijaNaziv, vrstaStudija.VrstaStudijaRazina, vrstaStudija.VrstaStudijaOznaka, vrstaStudija.TipStudijskogPrograma });
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

        }






    }
}