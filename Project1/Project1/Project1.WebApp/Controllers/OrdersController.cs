using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StoreDbContext _context;

        public OrdersController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Orders

        public async Task<IActionResult> Index(string orderLocation, string searchString)
        {
            IQueryable<string> locationQuery = from l in _context.TempOrders
                                               orderby l.Location.Name
                                               select l.Location.Name;
            var orders = _context.TempOrders.Include("Location").Include("Customer");

            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Customer.FName.Contains(searchString) || s.Customer.LName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(orderLocation))
            {
                orders = orders.Where(x => x.Location.Name == orderLocation);
            }
            var tempOrderVM = new TempOrderViewModel
            {
                Locations = new SelectList(await locationQuery.Distinct().ToListAsync()),
                TempOrders = orders.ToList()
            };
            return View(tempOrderVM);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            IQueryable<string> locationQuery = from l in _context.Locations
                                               orderby l.Name
                                               select l.Name;
            var customerQuery = await _context.Customers.ToListAsync();
            var orderCreateVM = new OrderCreateViewModel
            {
                Locations = new SelectList(await locationQuery.Distinct().ToListAsync()),
                Customers = customerQuery
            };
            return View(orderCreateVM);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationName,CustomerID")] OrderCreateViewModel orderCreateVM)
        {
            var customer = await _context.Customers.Where(x => x.ID == orderCreateVM.CustomerID).FirstOrDefaultAsync();
            var location = await _context.Locations.Where(x => x.Name == orderCreateVM.LocationName).FirstOrDefaultAsync();
            if(customer !=null && location != null)
            {
                try
                {
                    var order = new TempOrder { Customer = customer, Location = location, Created = DateTime.Now };
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    int newID = order.ID;
                }
                catch (DbUpdateException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));

            }
            return NotFound();
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Created")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.TempOrders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.TempOrders.Include("Customer").Include("Location").Where(x => x.ID == id).FirstOrDefaultAsync();
            _context.TempOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/AddProduct
        public async Task<IActionResult> AddProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.TempOrders.Include("Location")
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            var inventoryList = await _context.Inventory.Include("Location").Include("Product").Where(x => x.Location.ID == order.Location.ID).ToListAsync();
            var orderAddProductVM = new OrderAddProductViewModel
            {
                Inventories = inventoryList,
                TempOrderID = id.Value
            };

            return View(orderAddProductVM);
        }

        // POST: Orders/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([Bind("Quantity,InventoryID,TempOrderID")] OrderAddProductViewModel order)
        {
            var tempOrder = await _context.TempOrders.Include("Customer").Include("Location").Where(x => x.ID == order.TempOrderID).FirstOrDefaultAsync();
            var inventoryItem = await _context.Inventory.Include("Product").Include("Location").Where(x => x.ID == order.InventoryID).FirstOrDefaultAsync();
            if (inventoryItem == null) RedirectToAction(nameof(Index));
            if (order.Quantity <= inventoryItem.Quantity)
            {
                var newOrderProduct = new TempOrderProduct
                {
                    TempOrder = tempOrder,
                    Product = inventoryItem.Product,
                    Quantity = inventoryItem.Quantity


                };
                if (tempOrder.Products == null)
                {
                    tempOrder.Products = new List<TempOrderProduct>();
                }
                tempOrder.Products.Add(newOrderProduct);
                try
                {
                    _context.Update(tempOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public async Task<IActionResult> CompleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = await _context.TempOrders.Include("Customer").Include("Location").Where(x => x.ID == id).FirstOrDefaultAsync();
            var orderProducts = await _context.TempOrderProducts.Include("Product").Include("TempOrder").Where(x => x.TempOrder.ID == id).ToListAsync();
            var permanentOrderProductList = new List<OrderProduct>();
            var orderProduct = new OrderProduct();
            foreach(var item in orderProducts)
            {
                orderProduct = new OrderProduct
                {
                    Product = item.Product,
                    Quantity = item.Quantity

                };
                permanentOrderProductList.Add(orderProduct);
            }
            var permanentOrder = new Order
            {
                Customer = order.Customer,
                Location = order.Location,
                Products = permanentOrderProductList,
                Created = DateTime.Now
            };
            return View(permanentOrder);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteOrder([Bind("Order")] Order order)
        {
            try
            {
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }

    }
}
