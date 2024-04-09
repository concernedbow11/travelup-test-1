using Microsoft.AspNetCore.Mvc;
using test_1.Models;

namespace test_1.Controllers
{
    public class ItemController : Controller
    {
        private List<Item> _items = new List<Item>(); // Simulated database

        // GET: Item
        public ActionResult Index()
        {
            return View(_items);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            _items.Add(item); // Add item to the list (simulated database)
            return RedirectToAction("Index");
        }
    }

}
