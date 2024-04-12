
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.ToDoContext.Entities
{
    public class Todo: Entity
    {
        public Todo() {  }

        public Todo(string title, string description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }

        public Todo(string title, string description, bool isCompleted, Guid idUser)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            IdUser = idUser;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }

        public Guid IdUser { get; private set; }
        public User User { get; private set; }


        public void EditAttributes(string title, string description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
