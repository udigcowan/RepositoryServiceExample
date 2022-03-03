using ToDo.Data;
using ToDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Repositories;

[ApiController]
[Route("[repository]")]


    public class Repository: IToDoRepository<ToDoItem, int>
    {
        private readonly ToDoContext context;
        public Repository(ToDoContext context)=>this.context=context;

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           var item =await context.ToDoItems.FirstOrDefaultAsync(b=>b.ID==id);
           if(item !=null) {
               context.Remove(item);
           }
        }
        [HttpGet]       
        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return await context.ToDoItems.Include(b=>b.Name)
                                          .Include(b=>b.IsComplete)
                                          .ToListAsync();  
        }

        [HttpGet("{id}")]
        public async Task<ToDoItem> GetByID(int id)
        {
            return await context.ToDoItems.FindAsync(id);
        }

        [HttpPost]
        public async Task<ToDoItem> Insert(ToDoItem entity)
        {
           await context.ToDoItems.AddAsync(entity);
           return entity;
        }

    
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
