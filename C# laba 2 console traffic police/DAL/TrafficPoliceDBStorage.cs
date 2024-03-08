using C__laba_2_console_traffic_police.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace C__laba_2_console_traffic_police.DAL
{
	public class TrafficPoliceDBStorage
	{
		private readonly TrafficPoliceContext _context;

		public TrafficPoliceDBStorage (TrafficPoliceContext context)
		{
			_context = context;
		}
		public List<Driver> GetAllDrivers()
		{
			return _context.Drivers.ToList<Driver>();
		}
		public List<Driver> GetCertainDriver(string driverSurname)
		{
			List<Driver> drivers = _context.Drivers.ToList<Driver>();
			return drivers.FindAll(x => x.DriverSurname.Equals(driverSurname));
		}
		public DriverLicence GetCertainDriverLicence(int choosenId)
		{
			List<DriverLicence> driverLicences= _context.DriversLicences.ToList();
			return driverLicences.Find(x => x.DriverLicenceId.Equals(choosenId));
		}
		public void AddVehicle(Vehicle vehicle)
		{
			_context.Vehicles.Add(vehicle);
			_context.SaveChanges();
		}
		public List<Vehicle> GetAllVehicles()
		{
			return _context.Vehicles.ToList<Vehicle>();
		}
		public List<Model> GetAllModels()
		{
			return _context.Models.ToList<Model>();
		}

		public string GetCertainMarkName(int choosenId)
		{
			List<Mark> marks = _context.Marks.ToList();
			return marks.Find(x => x.MarkId.Equals(choosenId)).MarkName;
		}
		public Model GetCertainModel(int choosenId) 
		{
			List<Model> models = _context.Models.ToList<Model>();
			return models.Find(x => x.ModelId.Equals(choosenId));
		}
		public List<Vehicle> GetCertainVehicles(int choosenId)
		{
			List<Vehicle> vehicles = _context.Vehicles.ToList<Vehicle>();
			return vehicles.FindAll(x => x.DriverID.Equals(choosenId));
		}
		public void EditVehicle(Vehicle vehicle)
		{
			_context.Entry(vehicle).State = EntityState.Modified;
			_context.SaveChanges();
		}
		public List<Penalty> GetCertainPenalties(int choosenId)
		{
			List<Penalty> penalties = _context.Penalties.ToList();
			return penalties.FindAll(x => x.DriverLicenceID.Equals(choosenId));
		}
		public Violation GetCertainViolation(int choosenId)
		{
			List<Violation> violations = _context.Violations.ToList();
			return violations.Find(x => x.ViolationId.Equals(choosenId));
		}
	}
}
