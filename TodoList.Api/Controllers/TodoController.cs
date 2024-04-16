using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using TodoList.Domain.ToDoContext.Commands.ToDo.Handler;
using TodoList.Domain.ToDoContext.Commands.ToDo.Inputs;
using TodoList.Domain.ToDoContext.Commands.ToDo.Results;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;
using TodoList.Infra.Repository;
using TodoList.Shared.ToDoContext.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _todoRepository;

        public TodoController(TodoHandler handler, ITodoRepository todoRepository)
        {
            _handler = handler;
            _todoRepository = todoRepository;
        }

        [HttpPost]
        [Route("v1/post")]
        [AllowAnonymous]
        public async Task<ICommandResult> Create([FromBody] CreateTodo cammand)
        {
            var result = (TodoCommandResult)await _handler.ManipularAsync(cammand);

            return result;

        }

        [HttpPut]
        [Route("v1/edit")]
        [AllowAnonymous]
        public async Task<ICommandResult> Edit([FromBody] EditTodo cammand)
        {
            var result = (TodoCommandResult)await _handler.ManipularAsync(cammand);

            return result;

        }

        [HttpDelete]
        [Route("v1/delete")]
        [AllowAnonymous]
        public async Task<ICommandResult> Delete([FromBody] DeleteTodo cammand)
        {
            var result = (TodoCommandResult)await _handler.ManipularAsync(cammand);

            return result;
        }

        [HttpGet]
        [Route("v1/getTodo/{IdUser:Guid}/{page:int}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Todo>> getTodo(Guid IdUser, int page)
        {
           var list = await _todoRepository.GetAllToDoPerUser(IdUser, page);

            return list;
        }

        [HttpPost]
        [Route("v1/toggle-status/{idTodo:Guid}")]
        [AllowAnonymous]
        public async Task<ICommandResult> ToggleStatus(Guid idTodo)
        {
            var command = new UpdateStatusTodo();
            command.IdTodo = idTodo;
            var result = (TodoCommandResult)await _handler.ManipularAsync(command);

            return result;
        }

    }
}
