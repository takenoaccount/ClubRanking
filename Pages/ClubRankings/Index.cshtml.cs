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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesClubRanking.Data.RazorPagesClubRankingContext _context;

        public IndexModel(RazorPagesClubRanking.Data.RazorPagesClubRankingContext context)
        {
            _context = context;
        }

        public IList<ClubRanking> ClubRanking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClubRanking = await _context.ClubRanking.ToListAsync();
        }
    }
}
