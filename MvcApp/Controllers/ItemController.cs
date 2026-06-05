
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using System.Collections.Generic;
using MvcApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            var item = await _context.Items.ToListAsync();
            return View(item);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
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
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
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

        // [HttpPost()][HttpDelete("delete")]
        // public async Task<IActionResult> DeleteConfirm(int id)
        // {
        //     var item = await _context.Items.FindAsync(id);
        //     if(item != null)
        //     {
        //         _context.Items.Remove(item);
        //         await _context.SaveChangesAsync();
        //     }
        //     return View("Index");
        // }


    }
}