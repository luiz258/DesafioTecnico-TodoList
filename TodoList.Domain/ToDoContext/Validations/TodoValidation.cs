using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;

namespace TodoList.Domain.ToDoContext.Validations
{
    public class TodoValidation : AbstractValidator<Todo>
    {
        public TodoValidation()
        {
            RuleFor(model => model.Title).NotEmpty().MinimumLength(3).MaximumLength(150);
            RuleFor(model => model.Description).NotEmpty().MinimumLength(3).MaximumLength(250);
            RuleFor(model => model.IsCompleted).NotEmpty();
        }
    }
}
