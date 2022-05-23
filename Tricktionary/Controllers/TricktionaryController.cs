using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tricktionary.Models;
using Tricktionary.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Tricktionary.Controllers
{
    public class TricktionaryController : Controller
    {
        private TrickContext _context;
        public TricktionaryController(TrickContext ctx)
        {
            _context = ctx;
        }
        public IActionResult Show(int id)
        {
            Trick t = _context.Tricks.FirstOrDefault(m => m.Id == id);
            if (t == null)
                return Content("Trick not found");
            else {
                t.Image = "\\Images\\" + t.Name + ".jpg";
            }
            return View(t);
        }
        public IActionResult Index()
        {
            return View(_context.Tricks.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trick t)
        {
            if (!ModelState.IsValid) return View();

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                t.Image = "\\Images\\" + t.Name + ".jpg";
                ms.Close();
                ms.Dispose();
            }
            _context.Tricks.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Trick t = _context.Tricks.FirstOrDefault(m => m.Id == id);
            if (t != null) return View(t);
            else return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Trick changes)
        {
            if (!ModelState.IsValid)
                return View();

            //find the trick in the database that needs to be changed
            Trick t = _context.Tricks.First(m => m.Id == changes.Id);

            if (t == null)
                return Content("ERROR!!!!!");

            //save those changes into the database
            t.Name = changes.Name;
            t.Description = changes.Description;
            t.Image = changes.Image;

            _context.Tricks.Update(t); //save changes to the server copy of the database
            _context.SaveChanges();   //save changes to the database


            //go back to the list of Tricks
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Trick t = _context.Tricks.First(m => m.Id == id);
            if (t == null) //not found!
                return Content("ERROR");
            _context.Tricks.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
