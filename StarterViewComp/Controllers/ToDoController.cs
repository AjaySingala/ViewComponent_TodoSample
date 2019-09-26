using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _ToDoContext;

        public ToDoController(ToDoContext context)
        {
            _ToDoContext = context;

            // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
            // see: https://github.com/aspnet/EntityFrameworkCore/issues/11666 
            _ToDoContext.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var model = _ToDoContext.ToDo.ToList();
            return View(model);
        }

        public IActionResult PriorityList()
        {
            return ViewComponent("PriorityList", new { maxPriority = 2, isDone = false });
        }

        public IActionResult IndexNameof()
        {
            return View(_ToDoContext.ToDo.ToList());
        }

        public IActionResult PriorityListSync()
        {
            return ViewComponent("PriorityListSync", new { maxPriority = 3, isDone = true });
        }
        public IActionResult PriorityListTagHelper()
        {
            return View(_ToDoContext.ToDo.ToList());
        }
    }
}
