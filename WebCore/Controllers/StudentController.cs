using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    [Authorize]
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration config)
        {
            this.configuration = config;
        }

        ScriptHelper reader = new ScriptHelper();

        // GET:api/Student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<StudentDto> student = null;
            string sqlString = reader.Read("SqlScripts/Student/GetAll.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    student = await connection.QueryAsync<StudentDto>(sqlString);
                }

                return Ok(student);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

        }



        // GET: api/Student/5
        [HttpGet("{DprotocolID}")]
        public async Task<IActionResult> Get(int DprotocolID)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<StudentDto> student = null;
            string sqlString = reader.Read("SqlScripts/Student/GetID.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    student = await connection.QueryAsync<StudentDto>(sqlString, new { DprotocolID});
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }



        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Student/5
        [HttpPut("{DprotocolID}")]
        public async Task<IActionResult> Put(int DprotocolID, [FromBody] StudentDto student)
        {
            string connectionString = configuration.GetConnectionString("DocSys");
            string sqlString = reader.Read("SqlScripts/Student/Put.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sqlString, new
                    {
                        student.JMBAG,
                        student.Spol,
                        student.RodenjeDatum,
                        student.ImeRoditelja,
                        student.MjestoRodjenja,
                        student.PbrMjestaRodenja,
                        student.Mail,
                        student.Telefon,
                        student.MjestoStanovanja,
                        student.PbrStanovanja,
                        student.Ulica,
                        student.KucniBroj,
                       DprotocolID
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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
