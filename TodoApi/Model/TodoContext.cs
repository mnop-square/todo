using Microsoft.EntityFrameworkCore;

public class TodoItem
   {
       public int Id { get; set; }
       public string? Title { get; set; }
       public bool IsCompleted { get; set; }
   }

   public class TodoContext : DbContext
   {
       public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
       public DbSet<TodoItem> TodoItems { get; set; }
   }