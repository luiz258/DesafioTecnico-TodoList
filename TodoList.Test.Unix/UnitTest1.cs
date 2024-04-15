
using FluentValidation;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Validations;

namespace TodoList.Test.Unix
{
    public class UnitTest1
    {
        private TodoValidation _todoValidation;

        public UnitTest1()
        {
            _todoValidation = new TodoValidation();
        }

        [Fact]
        public async Task Test1()
        {
            var todo = new Todo("Tes", "tes", false);

            //Action
            var validation = await _todoValidation.ValidateAsync(todo);

            //Assert
            Assert.True(validation.Errors.Count > 0);
        }
    }
}