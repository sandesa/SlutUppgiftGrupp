namespace CampSleepAway2._0;

public class Camper
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<NextOfKin>? Kins { get; set; }
    public ICollection<CamperStay>? Stays { get; set; } 
}