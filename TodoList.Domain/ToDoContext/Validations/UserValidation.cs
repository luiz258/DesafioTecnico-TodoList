using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;

namespace TodoList.Domain.ToDoContext.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(model => model.FullName).NotEmpty().MinimumLength(5).MaximumLength(150);
            RuleFor(model => model.UserName).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(model => model.Password).NotEmpty().MinimumLength(8);
        }
    }
}
