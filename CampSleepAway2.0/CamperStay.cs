using CampSleepAway2._0;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CamperStay
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("CamperId")]
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;

    [Required]
    [ForeignKey("CabinId")]
    public int CabinId { get; set; }
    public Cabin Cabin { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
