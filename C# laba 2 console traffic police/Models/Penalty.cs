using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
	public class Penalty
	{
		[Key]
		public int? PenaltyId { get; set; }
		[Required]
		public string? Date { get; set; }
		[Required]
		public string? Time { get; set; }
		[Required]
		public string? District { get; set; }

		public int violationID { get; set; }
		//public Violation? violation { get; set; }
		public int? DriverLicenceID { get; set; }
		//public DriverLicence? driverLicence { get; set; }
	}
}
