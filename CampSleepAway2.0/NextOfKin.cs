using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;

public class NextOfKin
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    [Required]
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;
}