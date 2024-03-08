using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
    public class Model
    {
        [Key]
        public int? ModelId { get; set; }
        [Required]
        public string? ModelName { get; set; }

        public int MarkId { get; set; }
        //public Mark mark { get; set; } = null!;
        //public ICollection<Vehicle> vehicles { get; set; }= new List<Vehicle>();
    }
}
