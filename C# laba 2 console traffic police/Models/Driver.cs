using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police.Models
{
	public class Driver
	{
		[Key]
		public int DriverId { get; set; }
		[Required]
		public string? DriverName { get; set; }
		[Required]
		public string? DriverSurname { get; set; }
		public string? DriverMiddleName { get; set; }
		[Required]
		public string? DriverAddress { get; set; }
		[Required]
		public string? DriverPhoneNumber { get; set; }

		public int driverLicenceID { get; set; }
		//public DriverLicence driverLicence { get; set; } = null!;
		//public ICollection<Vehicle> vehicles { get; set; } = new List<Vehicle>();
	}
}
