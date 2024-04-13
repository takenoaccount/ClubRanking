using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesClubRanking.Data;
using RazorPagesClubRanking.Models;

namespace RazorPagesClubRanking.Pages.ClubRanking
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesClubRanking.Data.RazorPagesClubRankingContext _context;

        public EditModel(RazorPagesClubRanking.Data.RazorPagesClubRankingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClubRanking ClubRanking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubranking =  await _context.ClubRanking.FirstOrDefaultAsync(m => m.Id == id);
            if (clubranking == null)
            {
                return NotFound();
            }
            ClubRanking = clubranking;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ClubRanking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubRankingExists(ClubRanking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClubRankingExists(int id)
        {
            return _context.ClubRanking.Any(e => e.Id == id);
        }
    }
}
