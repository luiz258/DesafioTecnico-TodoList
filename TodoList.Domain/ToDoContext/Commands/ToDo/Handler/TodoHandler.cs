using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Commands.ToDo.Inputs;
using TodoList.Domain.ToDoContext.Commands.ToDo.Results;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;
using TodoList.Domain.ToDoContext.Validations;
using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Handler
{
    public class TodoHandler : ICommandHandler<CreateTodo>,
        ICommandHandler<EditTodo>,
        ICommandHandler<DeleteTodo>,
        ICommandHandler<UpdateStatusTodo>
    {
        private IValidator<Todo> _todoValidation;
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(IValidator<Todo> todoValidation, ITodoRepository todoRepositor)
        {
            _todoValidation = todoValidation;
            _todoRepository = todoRepositor;
        }
        public async Task<ICommandResult> ManipularAsync(CreateTodo command)
        {
            var ToDoDto = new Todo(command.Title, command.Description, command.IsCompleted, command.IdUser);

            ValidationResult resultValidation = await _todoValidation.ValidateAsync(ToDoDto);

            if (!resultValidation.IsValid) return new TodoCommandResult(false, "Error!", resultValidation.Errors);

            await _todoRepository.Salve(ToDoDto);

            return new TodoCommandResult(true, "Succes!", ToDoDto);

        }



        public async Task<ICommandResult> ManipularAsync(EditTodo command)
        {
           var todoObject = await _todoRepository.GetToDoById(command.Id);

            todoObject.EditAttributes(command.Title, command.Description, command.IsCompleted,command.CreateDate);

            ValidationResult resultValidation = await _todoValidation.ValidateAsync(todoObject);

            if (!resultValidation.IsValid) return new TodoCommandResult(false, "Error!", resultValidation.Errors);

            await _todoRepository.Edit(todoObject);

            return new TodoCommandResult(true, "Succes!", todoObject);
        }

        public async Task<ICommandResult> ManipularAsync(DeleteTodo command)
        {
           var delete = _todoRepository.Delete(command.Id);

            if(!delete) return new TodoCommandResult(false, "Error!", "Error deleted");
            
            
            return new TodoCommandResult(true, "Succes!", "Successfully deleted");
        }

        public async Task<ICommandResult> ManipularAsync(UpdateStatusTodo command)
        {
            var todoObject = await _todoRepository.GetToDoById(command.IdTodo);

            todoObject.toggleIsCompleteds();

            await _todoRepository.Edit(todoObject);

            return new TodoCommandResult(true, "Toggle value!", todoObject);
        }
    }
}
