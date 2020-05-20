using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.WebApp.Models;

namespace Project1.WebApp.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly StoreDbContext _context;

        public InventoriesController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index(string productLocation, string searchString)
        {
            IQueryable<string> locationQuery = from l in _context.Inventory
                                               orderby l.Location.Name
                                               select l.Location.Name;
            var inventories = _context.Inventory.Include("Product").Include("Location");


            if (!string.IsNullOrEmpty(searchString))
            {
                inventories = inventories.Where(s => s.Product.Name.Contains(searchString)).OrderBy(s => s.Product.Name);
            }
            if (!string.IsNullOrEmpty(productLocation))
            {
                inventories = inventories.Where(x => x.Location.Name == productLocation);
            }
            var inventoryVM = new InventoryViewModel
            {
                Locations = new SelectList(await locationQuery.Distinct().ToListAsync()),
                InventoryItems = await inventories.OrderBy(s => s.Location.Name).ThenBy(l => l.Product.Name).ToListAsync()
                
                
            };
            return View(inventoryVM);
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public async Task<IActionResult> Create()
        {
            IQueryable<string> locationQuery = from l in _context.Locations
                                               orderby l.Name
                                               select l.Name;
            IQueryable<string> productQuery = from p in _context.Products
                                               orderby p.Name
                                               select p.Name;
            var inventoryCreateVM = new InventoryCreateViewModel
            {
                Locations = new SelectList(await locationQuery.Distinct().ToListAsync()),
                Products = new SelectList(await productQuery.Distinct().ToListAsync())
            };
            return View(inventoryCreateVM);
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryProduct","InventoryLocation","Quantity")] InventoryCreateViewModel inventoryCreateVM)

        {
            if (ModelState.IsValid)
            {
                var inventoryCheck = await _context.Inventory.Where(x => x.Location.Name == inventoryCreateVM.InventoryLocation && x.Product.Name == inventoryCreateVM.InventoryProduct).FirstOrDefaultAsync();
                if (inventoryCheck != null)
                {
                    try
                    {
                        inventoryCheck.Quantity += inventoryCreateVM.Quantity;
                        //inventoryCreateVM.ErrorMessage = "An inventory for this product at this location already exists.";
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Index));
                }
                var inventory = new Inventory
                {
                    Location = await _context.Locations.Where(x => x.Name == inventoryCreateVM.InventoryLocation).FirstOrDefaultAsync(),
                    Product = await _context.Products.Where(x => x.Name == inventoryCreateVM.InventoryProduct).FirstOrDefaultAsync(),
                    Quantity = inventoryCreateVM.Quantity
                };
                try
                {
                    _context.Add(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryCreateVM);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity")] Inventory inventory)
        {
            if (id != inventory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.ID == id);
        }
    }
}
