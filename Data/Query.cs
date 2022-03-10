using Microsoft.AspNetCore;
using ToDo.Models;
using HotChocolate;
using ToDo.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoQuery.Data{

    public class GraphQLQuery {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task <List<ToDoItem>> AllToDoAsync([Service] ToDoContext context) {
            return await context.ToDoItem.ToListAsync();
        }
    }
}