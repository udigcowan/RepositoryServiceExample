using System;
using System.ComponentModel.DataAnnotations;


namespace ToDo.Models{
    public class ToDoItem
    {
        public int ID {get; set;}
        public string? Name {get; set;}

        public bool IsComplete {get;set;}
    }
}