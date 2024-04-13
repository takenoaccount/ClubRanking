using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesClubRanking.Models;

namespace RazorPagesClubRanking.Data
{
    public class RazorPagesClubRankingContext : DbContext
    {
        public RazorPagesClubRankingContext (DbContextOptions<RazorPagesClubRankingContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesClubRanking.Models.ClubRanking> ClubRanking { get; set; } = default!;
    }
}
