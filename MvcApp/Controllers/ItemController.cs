
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    [Route("[controller]")]
    public class ItemsController : Controller
    {
       private readonly MvcContext _context;
        public ItemsController(MvcContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = _context.Items.ToListAsync();
            return View(item);
        }
    }
}