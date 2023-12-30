using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;

public class Visits
{
    public int Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;

    public ICollection<NextOfKin> NextOfKins { get; set; } = null!;
}
