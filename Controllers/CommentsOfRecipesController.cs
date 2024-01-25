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
    public class CommentsOfRecipesController : Controller
    {
        private readonly Caloracker1Context _context;

        public CommentsOfRecipesController(Caloracker1Context context)
        {
            _context = context;
        }

        // GET: CommentsOfRecipes
        public async Task<IActionResult> Index()
        {
            var caloracker1Context = _context.CommentsOfRecipe.Include(c => c.CalorackerUser).Include(c => c.Recipe);
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
                .Include(c => c.Recipe)
                .Where(c => c.RecipeId == id);

            return View(await caloracker1Context.ToListAsync());
        }
        // GET: CommentsOfRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsOfRecipe = await _context.CommentsOfRecipe
                .Include(c => c.CalorackerUser)
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentsOfRecipe == null)
            {
                return NotFound();
            }

            return View(commentsOfRecipe);
        }

        // GET: CommentsOfRecipes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id");
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id");
            return View();
        }

        // POST: CommentsOfRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ContentOfComment,RecipeId,UserId")] CommentsOfRecipe commentsOfRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentsOfRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", commentsOfRecipe.UserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", commentsOfRecipe.RecipeId);
            return View(commentsOfRecipe);
        }


        // GET: CommentsOfRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsOfRecipe = await _context.CommentsOfRecipe.FindAsync(id);
            if (commentsOfRecipe == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", commentsOfRecipe.UserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", commentsOfRecipe.RecipeId);
            return View(commentsOfRecipe);
        }

        // POST: CommentsOfRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ContentOfComment,RecipeId,UserId")] CommentsOfRecipe commentsOfRecipe)
        {
            if (id != commentsOfRecipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentsOfRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsOfRecipeExists(commentsOfRecipe.Id))
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
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", commentsOfRecipe.UserId);
            ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id", commentsOfRecipe.RecipeId);
            return View(commentsOfRecipe);
        }

        // GET: CommentsOfRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsOfRecipe = await _context.CommentsOfRecipe
                .Include(c => c.CalorackerUser)
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentsOfRecipe == null)
            {
                return NotFound();
            }

            return View(commentsOfRecipe);
        }

        // POST: CommentsOfRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentsOfRecipe = await _context.CommentsOfRecipe.FindAsync(id);
            if (commentsOfRecipe != null)
            {
                _context.CommentsOfRecipe.Remove(commentsOfRecipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsOfRecipeExists(int id)
        {
            return _context.CommentsOfRecipe.Any(e => e.Id == id);
        }
    }
}
