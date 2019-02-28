using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Models;
using CPAT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class StudentPlanController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StudentPlanController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: StudentPlan
        public async Task<IActionResult> Index(string searchString)
        {
            var student = from s in _db.Students
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.LastName.StartsWith(searchString) || s.N_Number.StartsWith(searchString));
            }

            var studentFound = await student.FirstOrDefaultAsync();

            return View(nameof(Details), await student.FirstOrDefaultAsync());
        }

        // GET: StudentPlan/Details/5
        public async Task<IActionResult> Details(Students student)//int id
        {
            Courses c1 = await _db.Courses.FindAsync(4);
            Courses c2 = await _db.Courses.FindAsync(5);
            Courses c3 = await _db.Courses.FindAsync(6);
            Courses c4 = await _db.Courses.FindAsync(7);
            Courses c5 = await _db.Courses.FindAsync(8);

            ViewBag.Course1 = c1;
                
            /*
            var majorName = from m in _db.MajorRequirements
                            select m;
            
            majorName = majorName.Where(n => n.Id == student.MajorId);
            
            ViewBag.Major = majorName;
            
            var aTerm = from t in _db.AcademicTerms
                        select t;

            ViewBag.newTerm1 = await aTerm.FirstOrDefaultAsync();
            */
            return View();
        }

        // GET: StudentPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentPlan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentPlan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentPlan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentPlan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}