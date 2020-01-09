using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebCore.Models;
using WebCore.SqlScripts;

namespace WebCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IConfiguration configuration;

        public AuthController(IConfiguration config)
        {
            this.configuration = config;
        }

        ScriptHelper reader = new ScriptHelper();

        [HttpGet("tokenStudentAccess/{Email}/{Password}")]
        public async Task<IActionResult> GetStudentToken(string Email, string password)
        {
            int exist = 0;
            string getKey = configuration.GetSection("Authorization")["SecurityKey"];

            string connectionString = configuration.GetConnectionString("DocSys");
            IEnumerable<StudentDto> student = null;
            string sqlString = reader.Read("SqlScripts/Student/Login.sql");

            ProtocolIDTokenRequest tokenData = new ProtocolIDTokenRequest();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    student = await connection.QueryAsync<StudentDto>(sqlString, new { Email });

                    exist = student.Count();
                    var studentList = student.ToList();
                    tokenData.OIB = studentList[0].OIB;
                    tokenData.Ime = studentList[0].Ime;
                    tokenData.Prezime = studentList[0].Prezime;
                    tokenData.JMBAG = studentList[0].JMBAG;
                    tokenData.Email = studentList[0].Mail;
                    tokenData.ProtocolID = studentList[0].DProtocolID;
                }

                if (exist > 0 && password == "Test")
                {
                    var claims = new[]
                    {
                         new Claim(ClaimTypes.Name, tokenData.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(getKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(

                        issuer: "netCore.com",
                        audience: "netCore.com",
                        claims: claims,
                        expires: DateTime.Now.AddHours(2),
                        signingCredentials: creds
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    tokenData.Token = tokenString;

                    return Ok(tokenData);
                }

                return BadRequest("Bad request, check your input data!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

        }








    }//controller
}