using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;

public class Councelor
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<CouncelorAssignment>? CabinAssignments{ get; set; }

}