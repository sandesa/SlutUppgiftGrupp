using CampSleepAway2._0;

public class CamperStay
{
    public int Id { get; set; }
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;

    public int CabinId { get; set; }
    public Cabin Cabin { get; set; } = null!;

    public DateTime StartDate  { get; set; }
    public DateTime? EndDate { get; set; }
}
