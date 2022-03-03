using Microsoft.EntityFrameworkCore;
using ToDo.Models;


namespace ToDo.Data {
    public class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.UseSerialColumns();
            }
            public DbSet<ToDoItem> ToDoItems {get;set;}
    }
}