﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAway2._0;

public class Visit
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    [ForeignKey("CamperId")]
    public int CamperId { get; set; }
    public Camper Camper { get; set; } = null!;

    public ICollection<NextOfKin> NextOfKins { get; set; } = null!;
}
