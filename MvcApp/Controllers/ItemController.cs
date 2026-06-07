
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using System.Collections.Generic;
using MvcApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet("item")]

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.Include(s => s.SerialNumber)
                                           .Include(c => c.Category)
                                           .Include(ic => ic.ItemClients)
                                           .ThenInclude(c => c.Client)
                                           .ToListAsync();
            return View(item);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, Category")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }
        [HttpPost("delete"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }




    }
}