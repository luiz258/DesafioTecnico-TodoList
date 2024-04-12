using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.ToDoContext.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
