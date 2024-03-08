using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
    public class Mark
    {
        [Key]
        public int? MarkId { get; set; }
        [Required]
        public string? MarkName { get; set; }

        //public ICollection<Model> models { get; set; } = new List<Model>();
    }
}
