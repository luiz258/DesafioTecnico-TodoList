using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Shared.ToDoContext.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
