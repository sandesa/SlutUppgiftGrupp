namespace CampSleepAway2._0;

public class Councelor
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public ICollection<CouncelorAssignments>? CabinAssignments{ get; set; }

}