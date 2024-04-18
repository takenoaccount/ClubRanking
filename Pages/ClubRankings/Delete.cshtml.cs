using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesClubRanking.Data;
using RazorPagesClubRanking.Models;

namespace RazorPagesClubRanking.Pages.ClubRankings
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesClubRanking.Data.RazorPagesClubRankingContext _context;

        public DeleteModel(RazorPagesClubRanking.Data.RazorPagesClubRankingContext context)
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

            var clubranking = await _context.ClubRanking.FirstOrDefaultAsync(m => m.Id == id);

            if (clubranking == null)
            {
                return NotFound();
            }
            else
            {
                ClubRanking = clubranking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubranking = await _context.ClubRanking.FindAsync(id);
            if (clubranking != null)
            {
                ClubRanking = clubranking;
                _context.ClubRanking.Remove(ClubRanking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
