using CampSleepAway2._0;
using System.ComponentModel.DataAnnotations;

public class CouncelorAssignment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CouncelorId { get; set; }
    public Councelor? Councelor { get; set; }

    [Required]
    public int CabinId { get; set; }
    public Cabin? Cabin { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
