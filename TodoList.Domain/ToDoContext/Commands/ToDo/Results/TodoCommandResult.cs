﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Results
{
    public class TodoCommandResult : ICommandResult
    {
        public TodoCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public TodoCommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
           
        }

        public TodoCommandResult(bool sucess)
        {
            Sucess = sucess;

        }

        public bool Sucess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
