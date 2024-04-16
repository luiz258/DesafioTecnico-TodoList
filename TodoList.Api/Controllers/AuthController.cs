using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text;
using TodoList.Api.jwt;
using TodoList.Domain.ToDoContext.Commands.Account.Input;
using TodoList.Domain.ToDoContext.Commands.Account.Inputs;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IValidator<User> _userValidation;
        public AuthController(IUserRepository repository, IValidator<User> userValidation)
        {
            _repository = repository;
            _userValidation = userValidation;
        }

        [HttpPost]
        [Route("v1/authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] Login account)
            {

            var encryptPassword = encrypt(account.Password);
            var userLogin = await _repository.Authenticate(account.UserName, encryptPassword);

            if (userLogin == null) return BadRequest("Authentication error! Username or password is invalid");

            var token = TokenService.GenerateToken(userLogin);

           var result = new
           {
                token = token,
                user = new
                {
                    userLogin.FullName,
                    userLogin.UserName,
                    userLogin.Password,
                    userLogin.Id
                }  
           };

            return Ok(result);

        }

        [HttpPost]
        [Route("v1/create-account")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccount account)
        {

            try
            {
                bool searchUserExist = await _repository.SearchforUserName(account.UserName);

                if (searchUserExist) return NotFound("UserName already exists!");


                var encryptPassword = encrypt(account.Password);
                var userData = new User(account.UserName, account.Password, account.FullName);
                ValidationResult resultValidation = await _userValidation.ValidateAsync(userData);

                if (!resultValidation.IsValid) return NotFound(resultValidation.Errors);

                _repository.Save(userData);
                return Ok();
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

        protected async Task<bool> ValidateCredentials(string userName, string password)
        {
            var userLogin = await _repository.Authenticate(userName, password);
            return userLogin != null;
        }

    }
}
