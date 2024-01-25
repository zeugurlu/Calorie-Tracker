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
    public class TracksController : Controller
    {
        private readonly Caloracker1Context _context;

        public TracksController(Caloracker1Context context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var caloracker1Context = _context.Track.Include(t => t.CalorackerUser);
            return View(await caloracker1Context.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .Include(t => t.CalorackerUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }
        public async Task<IActionResult> DetailsUserID(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracksForUser = await _context.Track
                .Include(t => t.CalorackerUser)
                .FirstOrDefaultAsync(m => m.UserId.Equals(id));
             
            if (tracksForUser == null)
            {
                return NotFound();
            }

            return View(tracksForUser);
        }


        // GET: Tracks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DailyCalorie,TotalBudget,Breakfast,Lunch,Dinner,CupWater,TotalKarbs,TotalProteins,TotalFats,UserId")] Track track)
        {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", track.UserId);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", track.UserId);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DailyCalorie,TotalBudget,Breakfast,Lunch,Dinner,CupWater,TotalKarbs,TotalProteins,TotalFats,UserId")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("DetailsUserID", new { id = track.UserId });
            }
            ViewData["UserId"] = new SelectList(_context.CalorackerUsers, "Id", "Id", track.UserId);
            return View(track);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDailyCalorie(string userId, int calorie, int karbs, int proteins, int fats)
        {
            var trackForUser = await _context.Track
                .Include(t => t.CalorackerUser)
                .FirstOrDefaultAsync(t => t.UserId.Equals(userId));

            if (trackForUser == null)
            {
                return NotFound();
            }

            trackForUser.DailyCalorie += calorie;
            trackForUser.TotalKarbs += karbs;
            trackForUser.TotalProteins += proteins;
            trackForUser.TotalFats += fats;

            try
            {
                _context.Update(trackForUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsUserID", new { id = trackForUser.UserId });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(trackForUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }










        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .Include(t => t.CalorackerUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Track.FindAsync(id);
            if (track != null)
            {
                _context.Track.Remove(track);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.Id == id);
        }
    }
}
