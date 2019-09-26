using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace StarterViewComp.ViewComponents
{
    public class PriorityListNamedViewComponent : ViewComponent
    {
        private readonly ToDoContext _db;

        public PriorityListNamedViewComponent(ToDoContext context)
        {
            _db = context;
        }

        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return _db.ToDo
                .Where(x => x.IsDone == isDone && x.Priority <= maxPriority)
                .ToListAsync();
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            string viewName = "Default";
            var items = await GetItemsAsync(maxPriority, isDone);

            if (maxPriority > 3 && isDone)
            {
                viewName = "PVC";
            }

            return View(viewName, items);
        }
    }
}