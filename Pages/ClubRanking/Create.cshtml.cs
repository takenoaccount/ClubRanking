using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesClubRanking.Data;
using RazorPagesClubRanking.Models;

namespace RazorPagesClubRanking.Pages.ClubRanking
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesClubRanking.Data.RazorPagesClubRankingContext _context;

        public CreateModel(RazorPagesClubRanking.Data.RazorPagesClubRankingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClubRanking ClubRanking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClubRanking.Add(ClubRanking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
