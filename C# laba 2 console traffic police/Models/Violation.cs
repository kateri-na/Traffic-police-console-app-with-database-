using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
    public class Violation
    {
        [Key]
        public int? ViolationId { get; set; }
        [Required]
        public string? ViolationType { get; set; }
        [Required]
        public int? Fine { get; set; }

        //public ICollection<Penalty>? penalties { get; set; }
    }
}
