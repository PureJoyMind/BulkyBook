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
    }
}
