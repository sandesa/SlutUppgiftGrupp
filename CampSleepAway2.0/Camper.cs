using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;

public class Camper
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<NextOfKin>? Kins { get; set; }
    public ICollection<CamperStay>? Stays { get; set; } 
}