using Moq;
using TodoList.Domain.ToDoContext.Commands.ToDo.Handler;
using TodoList.Domain.ToDoContext.Commands.ToDo.Inputs;
using TodoList.Domain.ToDoContext.Repositories;
using TodoList.Domain.ToDoContext.Validations;
using TodoList.Shared.ToDoContext.Commands;


namespace TodoList.Test.Handler
{
    [TestClass]
    public class TodoHandlerTest
    {

        [TestMethod]
        public async void RegisterTodoValid()
        {
            var commad = new CreateTodo();
            commad.Title = "title1 teste";
            commad.IsCompleted = false;
            commad.Description = "teste teste";
            commad.IdUser = new Guid("7862C243-B0D8-452E-9A69-80341894B138");

            var mock = new Mock<ITodoRepository>();
            var _todoValidation = new TodoValidation();

            var handler = new TodoHandler(_todoValidation, mock.Object);

            ICommandResult result = await handler.ManipularAsync(commad);

            Assert.IsNull(result);

        }
    }
}