using CampSleepAway2._0;

public class CouncelorAssignments
{
    public int Id { get; set; }
    public Councelor? Councelor { get; set; }

    public int CabinId { get; set; }
    public Cabin? Cabin { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
