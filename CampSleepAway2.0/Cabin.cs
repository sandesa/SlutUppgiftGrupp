using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;
public class Cabin
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    [Precision(4)]
    public int NumberOfResidence { get; set; }

    public CouncelorAssignment Councelor { get; set; } = null!;
    public ICollection<CamperStay> Stays { get; set; } = null!;
}