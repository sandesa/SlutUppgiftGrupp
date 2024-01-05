using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAway2._0;

public class NextOfKin
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    [Required]
    [ForeignKey("CamperId")]
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;
}