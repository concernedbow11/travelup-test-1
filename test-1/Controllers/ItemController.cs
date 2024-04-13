using Microsoft.AspNetCore.Mvc;
using test_1.Models;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace test_1.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context; // Add a DbContext field

        public ItemController(AppDbContext context) // Inject the DbContext in the constructor
        {
            _context = context;
        }

        // GET: Item
        public async Task<ActionResult> Index()
        {
            var items = await _context.Items.ToListAsync(); // Get all items from the database
            return View(items);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item); // Add item to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction("Index");
            }
            return View(item);
        }
        [HttpGet]
/*        public async Task<ActionResult> Edit()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }*/
        [HttpGet]
        public async Task<ActionResult> Delete()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        /*        // GET : Item/Edit
                [HttpGet]
                public async Task<ActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        var items = await _context.Items.ToListAsync();
                        return View(items);
                    }

                    var item = await _context.Items.FindAsync(id);

                    if (item == null)
                    {
                        return NotFound();
                    }

                    return View(item);
                }
        */
        /*// POST: Item/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, string newName, decimal newPrice)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = newName;
            item.Price = newPrice;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return Ok(); // Return a 200 OK response if the update was successful
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message); // Return a 500 Internal Server Error response if an error occurs
                }
                
            }
            return BadRequest(ModelState);
        }*/

        // GET: Item/Edit
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }


        // POST: Item/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error editing item: " + ex.Message);
                }
            }
            return View(item);
        }


        // GET: Item/Delete
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item); // Remove item from the context
            await _context.SaveChangesAsync(); // Save changes to the database 
            return RedirectToAction("Index");
        }

        // POST: Item/Delete
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item); // Remove item from the context
            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("Item/EditList")]
        public async Task<ActionResult> EditList()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        // POST: Item/AddItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Items.Add(item);
                    await _context.SaveChangesAsync();

                    // Return the newly added item as JSON
                    return Json(new { id = item.Id, name = item.Name, price = item.Price });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding item: " + ex.Message);
                }
            }

            // If there are validation errors or an exception occurred, return a bad request
            return BadRequest(ModelState);
        }


    }

}
