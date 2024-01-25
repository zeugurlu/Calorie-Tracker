using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caloracker1.Data;
using Caloracker1.Models;

namespace Caloracker1.Controllers
{
    public class CommentsController : Controller
    {
        private readonly Caloracker1Context _context;

        public CommentsController(Caloracker1Context context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var caloracker1Context = _context.Comment.Include(c => c.CalorackerUser).Include(c => c.Meal).Include(c => c.Recipe);
            return View(await caloracker1Context.ToListAsync());
        }

        public async Task<IActionResult> IndexOfRecipe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Filter comments based on the provided recipe ID
            var caloracker1Context = _context.Comment
                .Include(c => c.CalorackerUser)
                .Include(c => c.Meal)
                .Include(c => c.Recipe)
                .Where(c => c.RecipeId == id);

            return View(await caloracker1Context.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.CalorackerUser)
                .Include(c => c.Meal)
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id");
            ViewData["MealId"] = new SelectList(_context.Meal, "Id", "Id");
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ContentOfComment,RecipeId,UserId,MealId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", comment.UserId);
            ViewData["MealId"] = new SelectList(_context.Meal, "Id", "Id", comment.MealId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", comment.RecipeId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", comment.UserId);
            ViewData["MealId"] = new SelectList(_context.Meal, "Id", "Id", comment.MealId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", comment.RecipeId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ContentOfComment,RecipeId,UserId,MealId")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", comment.UserId);
            ViewData["MealId"] = new SelectList(_context.Meal, "Id", "Id", comment.MealId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", comment.RecipeId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.CalorackerUser)
                .Include(c => c.Meal)
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment != null)
            {
                _context.Comment.Remove(comment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
