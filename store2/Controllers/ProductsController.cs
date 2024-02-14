using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store2.Models;

namespace store2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            var Rusalt = _context.products
                .OrderBy(x => x.ProdectName).ToList();
            return View(Rusalt);
           
        }
        public IActionResult Showadmin()
        {
            var Rusalt = _context.products
                .OrderBy(x => x.ProdectName).ToList();
            return View(Rusalt);

        }
        public IActionResult Create()
        {
            
            //ViewBag.Department = _context.products.OrderBy(x => x.ProdectName).ToList();
            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products employee)
        {
            UploadImage(employee);

            if (employee != null)
            {
                _context.products.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));



            }


            //ViewBag.Department = _context.products.OrderBy(x => x.ProdectName).ToList();
            return View();

        }
            public IActionResult Edit(int? Id)
        {
            //ViewBag.Department = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            var Ruslut = _context.products.Find(Id);
            return View("Create",Ruslut);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products employee)
        {

            UploadImage(employee);
            if (employee != null)
            {
                _context.products.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Showadmin));
            }
            //ViewBag.Department = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View(employee);


        }
        public IActionResult Delete(int? Id)
        {

            var Ruslut = _context.products.Find(Id);
            if (Ruslut != null)
            {
                _context.products.Remove(Ruslut);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Showadmin));


        }

        private void UploadImage(Products employee)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string IageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images", IageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                employee.ProdectImage = IageName;

            }
            else if (employee.ProdectImage == null && employee.Id == null)
            {
                employee.ProdectImage = "Defultimageuser.jpg";
            }
            else
            {

                employee.ProdectImage = employee.ProdectImage;

            }
        }

        //private void uploadimage(Products employee)
        //{
        //    var file = HttpContext.Request.Form.Files;
        //    if (file.Count() > 0)
        //    {
        //        string IageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
        //        var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images", IageName), FileMode.Create);
        //        file[0].CopyTo(fileStream);
        //        employee.ProdectImage = IageName;

        //    }
        //    else if (employee.ProdectImage == null && employee.Id == null)
        //    {
        //        employee.ProdectImage = "Defultimageuser.jpg";
        //    }
        //    else
        //    {

        //        employee.ProdectImage = employee.ProdectImage;

        //    }
        //}


    }
}
