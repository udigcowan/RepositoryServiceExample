using System;
using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoService
    {
        List<ToDoItem> GetAll();
    }
}