using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using Microsoft.AspNetCore.Mvc;


namespace ToDo.Data {
    public class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
            {

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=ToDodb;port =5432; User Id =user, password=password");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.UseSerialColumns();
            }
            public DbSet<ToDoItem> ToDoItem {get;set;}
    }
}