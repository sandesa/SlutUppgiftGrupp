using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CampSleepAway2._0;

public class Camper
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<NextOfKin>? Kins { get; set; }
    public ICollection<CamperStay>? Stays { get; set; } 
}