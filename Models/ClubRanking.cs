using System.ComponentModel.DataAnnotations;

namespace RazorPagesClubRanking.Models;

public class ClubRanking
{
    public int Id { get; set; }
    public string? Club { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Name { get; set; }
    public decimal Rank { get; set; }
}