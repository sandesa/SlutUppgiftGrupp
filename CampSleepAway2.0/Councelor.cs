using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CampSleepAway2._0;

public class Councelor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<CouncelorAssignment>? CabinAssignments { get; set; }

}