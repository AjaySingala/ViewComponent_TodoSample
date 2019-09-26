//#define no_suffix
#if no_suffix

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentSample.Models;


namespace StarterViewComp.ViewComponents
{
    public class PriorityListNameof : ViewComponent
    {
        private readonly ToDoContext _db;

        public PriorityListNameof(ToDoContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);

            return View(items);
        }

        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return _db.ToDo
                .Where(x => x.IsDone == isDone && x.Priority <= maxPriority)
                .ToListAsync();
        }
    }
}
#endif
