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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesClubRanking.Data.RazorPagesClubRankingContext _context;

        public DetailsModel(RazorPagesClubRanking.Data.RazorPagesClubRankingContext context)
        {
            _context = context;
        }

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
    }
}
