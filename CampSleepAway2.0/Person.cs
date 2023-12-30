using System.ComponentModel.DataAnnotations;

namespace CampSleepAway2._0;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; } 
}