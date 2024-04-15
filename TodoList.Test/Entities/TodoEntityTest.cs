using FluentValidation;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Validations;

namespace TodoList.Test.Entities
{
    [TestClass]
    public class TodoEntityTest
    {
        private TodoValidation _todoValidation;
        public TodoEntityTest()
        {
            _todoValidation = new TodoValidation();
        }

        [TestMethod]
        public async Task TodoEntitieDeveSerInvalido()
        {
            //Arrange 
            var todo = new Todo(" ", " ", false);

            //Action
            var validation = await _todoValidation.ValidateAsync(todo);

            //Assert
            Assert.IsTrue(validation.Errors.Count > 0);
        }

        [TestMethod]
        public async Task TodoEntitieDeveSerValido()
        {
            //Arrange 
            var todo = new Todo("Teste 123", "Teste description", true);

            //Action
            var validation = await _todoValidation.ValidateAsync(todo);

            //Assert
            Assert.IsTrue(validation.Errors.Count == 0);
        }
    }
}