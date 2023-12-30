namespace CampSleepAway2._0;

public class NextOfKin
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;
}