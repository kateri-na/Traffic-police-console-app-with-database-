using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
    public class DriverLicence
    {
        [Key]
        public int? DriverLicenceId { get; set; }
        [Required]
        public string? BirthDate { get; set; }
        [Required]
        public string? PlaceOfBirth { get; set; }
        [Required]
        public string? IssueDate { get; set; }
        [Required]
        public string? ExpirationDate { get; set; }
        [Required]
        public string? IssuingAuthority { get; set; }

        //public Driver? driver { get; set; }
        //public ICollection<Penalty> penalties { get; set; } = new List<Penalty>();

    }
}
