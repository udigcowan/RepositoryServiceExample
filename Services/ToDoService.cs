using System;
using ToDo.Models;
using ToDo.Repositories;
using ToDo.Services;


namespace ToDoService
{
    public class ToDoService: IToDoService
    {
        private readonly IToDoRepository<ToDoItem, int> _ToDoRepo;

        public ToDoService(IToDoRepository<ToDoItem,int> ToDoRepo)
        {
            _ToDoRepo = ToDoRepo;
        }

        public List<ToDoItem> GetAll()=>_ToDoRepo.GetAll();
    }
}