using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
    public class Vehicle
    {
        [Key]
        public string? VIN { get; set; }
        [Required]
        public string? LicencePlateNumber { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public int? ManufactureYear { get; set; }
        [Required]
        public string? RegistrationDate { get; set; }
        public string? DeregistrationDate { get; set; }

        public int ModelID { get; set; }
        //public Model? model { get; set; }
        public int? DriverID { get; set; }
        //public Driver? driver { get; set; }
    }
}
