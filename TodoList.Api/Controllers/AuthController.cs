using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
             _repository = repository ;
        }

        [HttpPost]
        [Route("v1/Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] string username, string password)
        {
            var list = await _repository.Authenticate(username, password);

          
        }

        [HttpPost]
        [Route("v1/post")]
        public async Task<IActionResult> CreateAccount([FromBody] string userName, string password, string fullname)
        {
            try
            {
                var encryptPassword = encrypt(password);
                var userData = new User(userName, password, fullname);
                var result = _repository.Salve(userData);

                return Ok(result);
            }
            catch (Exception e)
            {

                return NotFound(e);
            }


        }

        protected string encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

    }
}
