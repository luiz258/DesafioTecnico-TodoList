

using Microsoft.EntityFrameworkCore;
using TodoList.Domain.ToDoContext.Entities;

namespace TodoList.Infra.DataContext
{
    public class TodoListDbContext: DbContext
    {
        public TodoListDbContext()
        {
                
        }

        public TodoListDbContext(DbContextOptions<TodoListDbContext> options): base(options)  {   }

        public DbSet<User> Users { get; set; }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
               
                entity.HasKey(u => u.Id);

                entity.Property(u => u.UserName)
                    .IsRequired(true)
                    .HasMaxLength(100);

                entity.Property(u => u.FullName)
                    .IsRequired(true)
                    .HasMaxLength(150);

                entity.Property(u => u.Password)
                   .IsRequired(true)
                   .HasMaxLength(200);
                
            });

            builder.Entity<Todo>(entity => {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title)
                    .IsRequired(true)
                    .HasMaxLength(100);

                entity.Property(t => t.Description)
                   .IsRequired(true)
                   .HasMaxLength(100);

                entity.Property(t => t.IsCompleted)
                   .IsRequired(true);

                entity.Property(t => t.CreateDate)
                   .IsRequired(true);

                entity.HasOne(t => t.User)
                    .WithMany(t => t.TodosLists)
                    .HasForeignKey(t => t.IdUser)
                    .IsRequired(true);

            });
        }
    }
}
