using System.Linq;
using Microsoft.AspNet.Mvc;
using TJ4.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TJ4.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbaccess;

        public CustomerController(ApplicationDbContext dbaccess)
        {
            _dbaccess = dbaccess;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_dbaccess.Customer.ToList());
        }

        //GET: Customers/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _dbaccess.Customer.Single(m => m.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("ID,Name,Surname,Phone,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbaccess.Customer.Add(customer);
                _dbaccess.Entry(customer).State = Microsoft.Data.Entity.EntityState.Added;
                _dbaccess.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5 - no edit, just returns a view to edit with a POST request
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _dbaccess.Customer.Single(m => m.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("ID,Name,Surname,Phone,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //   _dbaccess.Update(customer);

                _dbaccess.Customer.Add(customer);
                _dbaccess.Entry(customer).State = Microsoft.Data.Entity.EntityState.Modified;
              
                _dbaccess.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5 - no delete, just returns a view to delete it with a POST request
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customer customer = _dbaccess.Customer.Single(m => m.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Customer customer = _dbaccess.Customer.Single(m => m.ID == id);
            _dbaccess.Customer.Remove(customer);
            _dbaccess.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
