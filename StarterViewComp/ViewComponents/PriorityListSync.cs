using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace StarterViewComp.ViewComponents
{
    public class PriorityListSync : ViewComponent
    {
       private readonly ToDoContext _db;

        public PriorityListSync(ToDoContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke(int maxPriority, bool isDone)
        {
            var items = GetItems(maxPriority, isDone);

            return View(items);
        }

        private List<TodoItem> GetItems(int maxPriority, bool isDone)
        {
            return _db.ToDo
                .Where(x => x.IsDone == isDone && x.Priority <= maxPriority)
                .ToList();
        }
    }
}