using CampSleepAway2._0;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CouncelorAssignment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("CouncelorId")]
    public int CouncelorId { get; set; }
    public Councelor? Councelor { get; set; }

    [Required]
    [ForeignKey("CabinId")]
    public int CabinId { get; set; }
    public Cabin? Cabin { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
