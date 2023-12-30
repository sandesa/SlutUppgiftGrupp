namespace CampSleepAway2._0;
public class Cabin
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int NumberOfResidence { get; set; }

    public CouncelorAssignments Councelor { get; set; } = null!;
    public ICollection<CamperStay> Stays { get; set; } = null!;
}