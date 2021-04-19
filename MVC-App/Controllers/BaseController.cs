using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Model;

namespace MVC_App.Controllers
{
    public class BaseController<T1, T2> : Controller where T2 : BaseModel
    {
        private readonly IBaseRepo<T2> _context;

        public BaseController(IBaseRepo<T2> context)
        {
            this._context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(T2 studentModel)
        {
            if (ModelState.IsValid)
            {
                await _context.Insert(studentModel);
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,  T2 studentModel)
        {
            if (id != studentModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _context.Update(studentModel);
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
