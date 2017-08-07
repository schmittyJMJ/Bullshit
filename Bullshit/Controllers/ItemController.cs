using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bullshit.Models;

namespace Bullshit.Controllers
{
    public class ItemController : Controller
    {
        private ItemsContext db = new ItemsContext();
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(items => items.Id == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
