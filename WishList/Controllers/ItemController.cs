using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deleteItem = _context.Items.FirstOrDefault(item => item.Id == id);

            _context.Remove(deleteItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index(List<Item> items)
        {
            List<Item> list = new List<Item>();

            foreach (Item item in _context.Items)
            {
                list.Add(item);
            }
            return View("Index", list);
        }
    }
}
