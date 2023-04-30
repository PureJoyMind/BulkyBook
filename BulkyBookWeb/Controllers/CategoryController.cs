using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        // To have applicationDbContext work with the database
        private readonly ApplicationDbContext _db;

        // Then we need to tell the application that we need an implementation of _db
        // where the connection to db is already made
        public CategoryController(ApplicationDbContext dbContext) 
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            // Retrieving objects from db
            IEnumerable<Category> objectCategoryList = _db.Categories; // Can also use .ToList() with var
            return View(objectCategoryList);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }


        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] // not required
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order cannot have the same value.");
            }
            //if (!ModelState.IsValid) // Is tested in client
            //{
            //    return View(obj);
            //}
            _db.Categories.Add(obj); // not saved to the database
            _db.SaveChanges(); // saved to the database
            return RedirectToAction("Index"); // looks for action inside the same controller
            
            // to redirect to another action in another controller we feed the method
            // the controller name ("Action","Controller")
        }
    }
}

