using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebCore.Models;
using WebCore.SqlScripts;

namespace WebCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Molba")]
    public class MolbaController : Controller
    {

        private IConfiguration configuration;

        public MolbaController(IConfiguration config)
        {
            configuration = config;
        }

        ScriptHelper reader = new ScriptHelper();

        // GET: api/Molba
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<MolbaDto> molba = null;

            string sqlString = reader.Read("SqlScripts/Molba/GetAll.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    molba = await connection.QueryAsync<MolbaDto>(sqlString);
                }

                return Ok(molba);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }


        }

        // GET: api/Molba/5
        [HttpGet("{DProtocolIDStudent}")]
        public async Task<IActionResult> Get(int DProtocolIDStudent)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<MolbaDto> molba = null;

            string sqlString = reader.Read("SqlScripts/Molba/GetIDStudent.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    molba = await connection.QueryAsync<MolbaDto>(sqlString, new { DProtocolIDStudent });
                }
                return Ok(molba);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Doslo je do greske");
            }
        }
        
        // POST: api/Molba
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MolbaDto molba)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/Molba/Post.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlString, new
                    {
                        molba.InvaliditetInd,
                        molba.PotrebaZaPrilagodenomSobomInd,
                        molba.PotrebaZaAsistentomInd,
                        molba.MozeBitiSmjestenNaKatuInd,
                        molba.MozeBitiSmjestenNa1KatuInd,
                        molba.MozeBitiSmjestenNa2KatuInd,
                        molba.MozeBitiSmjestenNa3KatuInd,
                        molba.MozeBitiSmjestenNa4KatuInd,
                        molba.MozeBitiSmjestenUDvokrevetnojSobiInd,
                        molba.ApsolventZaostajanjeInd,
                        molba.ZalbaNegativnoInd,
                        molba.ZalbaPozitivnoInd,
                        molba.ZalbaUvjetnoInd,
                        molba.RektorovaNagradaBroj,
                        molba.DekanovaNagradaBroj,
                        molba.MedunarodnaNagradaBroj,
                        molba.DrzavnaNagradaBroj
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Greska");
            }
        }
        
        // PUT: api/Molba/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MolbaDto molba)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/Molba/Put.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlString, new
                    {
                        molba.InvaliditetInd,
                        molba.PotrebaZaPrilagodenomSobomInd,
                        molba.PotrebaZaAsistentomInd,
                        molba.MozeBitiSmjestenNaKatuInd,
                        molba.MozeBitiSmjestenNa1KatuInd,
                        molba.MozeBitiSmjestenNa2KatuInd,
                        molba.MozeBitiSmjestenNa3KatuInd,
                        molba.MozeBitiSmjestenNa4KatuInd,
                        molba.MozeBitiSmjestenUDvokrevetnojSobiInd,
                        molba.ApsolventZaostajanjeInd,
                        molba.ZalbaNegativnoInd,
                        molba.ZalbaPozitivnoInd,
                        molba.ZalbaUvjetnoInd,
                        molba.RektorovaNagradaBroj,
                        molba.DekanovaNagradaBroj,
                        molba.MedunarodnaNagradaBroj,
                        molba.DrzavnaNagradaBroj
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{DProtocolIDStudent}")]
        public async Task<IActionResult> Delete(int DProtocolIDStudent)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<MolbaDto> molba = null;

            string sqlString = reader.Read("SqlScripts/Molba/DeleteIDStudent.sql");

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    molba = await connection.QueryAsync<MolbaDto>(sqlString, new { DProtocolIDStudent });
                }
                return Ok(molba);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Doslo je do greske");
            }
        }
    }
}
