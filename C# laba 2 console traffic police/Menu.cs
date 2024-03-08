using C__laba_2_console_traffic_police.DAL;
using C__laba_2_console_traffic_police.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__laba_2_console_traffic_police
{
	public static class Menu
	{
		static TrafficPoliceDBStorage trafficPoliceDBStorage;

		static Menu()
		{
			trafficPoliceDBStorage = new TrafficPoliceDBStorage(new TrafficPoliceContext());
		}

		private static void ViewDriverInformation()
		{
			List<Driver> drivers = trafficPoliceDBStorage.GetAllDrivers();
			foreach (Driver driver in drivers)
			{
				Console.WriteLine(driver.DriverId);
				Console.WriteLine(driver.DriverSurname + " " + driver.DriverName + " " + driver.DriverMiddleName);
				Console.WriteLine("Адрес водителя: " + driver.DriverAddress);
				Console.WriteLine("Телефонный номер водителя: " + driver.DriverPhoneNumber);
				DriverLicence driverLicence = trafficPoliceDBStorage.GetCertainDriverLicence(driver.driverLicenceID);
				Console.WriteLine("Информация о водительском удостоверении: ");
				Console.WriteLine("Дата рождения водителя: " + driverLicence.BirthDate);
				Console.WriteLine("Место рождения водителя: " + driverLicence.PlaceOfBirth);
				Console.WriteLine("Дата выдачи водительского удостоверения: " + driverLicence.IssueDate);
				Console.WriteLine("Дата окончания срока действия водительского удостоверения: " + driverLicence.ExpirationDate);
				Console.WriteLine("Подразделение Госавтоинспекции, выдавшей удостоверение: " + driverLicence.IssuingAuthority);
				Console.WriteLine();
			}
		}

		private static void ViewVehicleInformation(List<Vehicle> vehicles)
		{
			foreach (Vehicle vehicle in vehicles)
			{
				Console.WriteLine("VIN: " + vehicle.VIN);
				Console.WriteLine("ГОС-номер автомобиля " + vehicle.LicencePlateNumber);
				Console.WriteLine("Цвет автомобиля: " + vehicle.Color);
				Console.WriteLine("Дата выпуска автомобиля: " + vehicle.ManufactureYear);
				Console.WriteLine("Дата регистрации в ГАИ: " + vehicle.RegistrationDate);
				Console.WriteLine("Дата снятия с регистрации в ГАИ: " + vehicle.DeregistrationDate);
				Console.WriteLine("Идентификатор владельца: " + vehicle.DriverID);
				Model model = trafficPoliceDBStorage.GetCertainModel(vehicle.ModelID);
				Console.WriteLine("Модель и марка автомобиля: " + model.ModelName + "," + trafficPoliceDBStorage.GetCertainMarkName(model.MarkId));
				Console.WriteLine();
			}
		}

		private static void ViewPenaltyInformation(List<Penalty> penalties)
		{
			foreach (Penalty penalty in penalties)
			{
				Console.WriteLine("Дата совершения нарушения: " + penalty.Date);
				Console.WriteLine("Время совершения нарушения: " + penalty.Time);
				Console.WriteLine("Район совершения правонарушения: " + penalty.District);
				Console.WriteLine("Тип нарушения: " + trafficPoliceDBStorage.GetCertainViolation(penalty.violationID).ViolationType);
				Console.WriteLine("Штраф: " + trafficPoliceDBStorage.GetCertainViolation(penalty.violationID).Fine);
			}
		}

		private static void ViewDriverAndTheirID(List<Driver> drivers)
		{
			Console.WriteLine("Список водителей и их идентификаторов:");
			foreach (Driver driver in drivers)
			{
				Console.WriteLine(driver.DriverId + "-" + driver.DriverSurname + " " + driver.DriverName + " " + driver.DriverMiddleName);
			}
		}
		public static void StartStep()
		{
			Console.WriteLine("Данные о водителях и их водительских удостоверениях, хранящиеся в базе данных:");
			Console.WriteLine();
			ViewDriverInformation();
		}
		public static void FirstStep()
		{
			Vehicle vehicle = new Vehicle();
			Console.WriteLine("Введите информацию о транспортном средстве:");
			Console.WriteLine("Введите VIN - номер");
			vehicle.VIN = Console.ReadLine();
			Console.WriteLine("Введите ГОС-номер автомобиля");
			string LicencePlateNumber = Console.ReadLine();
			if (LicencePlateNumber.Count() == 8 || LicencePlateNumber.Count() == 9)
			{
				vehicle.LicencePlateNumber = LicencePlateNumber.ToUpper();
				Console.WriteLine("Введите цвет автомобиля");
				vehicle.Color = Console.ReadLine();
				Console.WriteLine("Введите год выпуска автомобиля");
				try
				{
					vehicle.ManufactureYear = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Введите дату постановки на регистрацию в формате yyyy-mm-dd");
					vehicle.RegistrationDate = Console.ReadLine();
					List<Model> models = trafficPoliceDBStorage.GetAllModels();

					Console.WriteLine("Выберите индентификатор модели автомобиля");
					foreach (Model model in models)
					{
						Console.WriteLine(model.ModelId + "-" + model.ModelName + "," + trafficPoliceDBStorage.GetCertainMarkName(model.MarkId));
					}
					try
					{
						int choiseModel = Convert.ToInt32(Console.ReadLine());
						if (choiseModel >= 1 && choiseModel <= models.Count)
						{
							List<Driver> drivers = trafficPoliceDBStorage.GetAllDrivers();
							ViewDriverAndTheirID(drivers);
							vehicle.ModelID = choiseModel;
							Console.WriteLine("Введите идентификатор водителя, которому принадлежит автомобиль");
							try
							{
								int choiseDriver = Convert.ToInt32(Console.ReadLine());
								if (choiseDriver >= 1 && choiseDriver <= drivers.Count())
								{
									vehicle.DriverID = choiseDriver;
									trafficPoliceDBStorage.AddVehicle(vehicle);
									Console.WriteLine("Список автомобилей, занесенных в базу данных ГАИ");
									List<Vehicle> vehicles = trafficPoliceDBStorage.GetAllVehicles();
									ViewVehicleInformation(vehicles);
								}
								else
								{
									Console.WriteLine("Водителя с выбранным вами идентификатором не существует в базе данных");
								}
							}
							catch
							{
								Console.WriteLine("Недопустимый формат индентификатора водителя");
							}
						}
						else
						{
							Console.WriteLine("Модели с выбранным вами идентинтификатором не существует в базе данных");
						}

					}
					catch
					{
						Console.WriteLine("Недопустимый формат индентификатора модели");
					}
				}
				catch
				{
					Console.WriteLine("Недопустимый формат года выпуска");
				}
			}
			else
			{
				Console.WriteLine("Некорректное число символов в ГОС-номере");
			}
		}
		public static void SecondStep()
		{
			List<Driver> drivers = trafficPoliceDBStorage.GetAllDrivers();
			ViewDriverAndTheirID(drivers);
			Console.WriteLine("Введите идентификатор водителя, чьё транспортное средство вы хотите снять с регистрации");
			try
			{
				int choiseDriver = Convert.ToInt32(Console.ReadLine());
				if (choiseDriver >= 1 && choiseDriver <= drivers.Count())
				{
					List<Vehicle> vehicles = trafficPoliceDBStorage.GetCertainVehicles(choiseDriver);
					Console.WriteLine("Транспортные средства, принадлежащие водителю:");
					ViewVehicleInformation(vehicles);
					Console.WriteLine("Введите VIN транспортного средства, которое вы хотите снять с регистрации:");
					string choiseVIN = Console.ReadLine();
					choiseVIN = choiseVIN.Trim();
					Vehicle choiseVehicle = vehicles.Find(x => x.VIN.Equals(choiseVIN));
					if (choiseVehicle != null)
					{
						if (choiseVehicle.DeregistrationDate == null)
						{
							Console.WriteLine("Введите дату снятия с регистрации в формате yyyy-mm-dd:");
							choiseVehicle.DeregistrationDate = Console.ReadLine();
							trafficPoliceDBStorage.EditVehicle(choiseVehicle);
							Console.WriteLine();
							Console.WriteLine("Обновленная база данных траспортных средств: ");
							ViewVehicleInformation(trafficPoliceDBStorage.GetAllVehicles());
						}
						else
						{
							Console.WriteLine("Транспортное средство уже снято с регистрации");
						}
					}
					else
					{
						Console.WriteLine("Введен некорректный VIN");
					}
				}
				else
				{
					Console.WriteLine("Водителя с выбранным вами идентификатором не существует в базе данных");
				}
			}
			catch
			{
				Console.WriteLine("Недопустимый формат идентификатора водителя");
			}
		}
		public static void ThirdStep()
		{
			Console.WriteLine("Введите фамилию водителя, информацию о чьих правонарушениях вы хотите запросить:");
			string ChoiseSurname = Console.ReadLine();

			List<Driver> drivers = trafficPoliceDBStorage.GetCertainDriver(ChoiseSurname);
			List<Driver> allDrivers = trafficPoliceDBStorage.GetAllDrivers();
			int ChoiseDriverId = 0;

			if (drivers.Count() <= 0)
			{
				Console.WriteLine("В базе данных не существует водителя с такой фамилией");
			}
			else
			{
				if (drivers.Count() == 1)
				{
					ChoiseDriverId = drivers[0].driverLicenceID;
				}
				else
				{
					Console.WriteLine("В базе данных существует несколько водителей с такой фамилией");
					Console.WriteLine("Выберите номер нужного вам водителя");
					ViewDriverAndTheirID(drivers);
					try
					{
						ChoiseDriverId = Convert.ToInt32(Console.ReadLine());
					}
					catch
					{
						Console.WriteLine("Недопустимый формат идентификатора водителя");
					}
				}
				if (ChoiseDriverId >= 1 && ChoiseDriverId <= allDrivers.Count())
				{
					List<Penalty> penalties = trafficPoliceDBStorage.GetCertainPenalties(ChoiseDriverId);
					if (penalties.Count() != 0)
					{
						ViewPenaltyInformation(penalties);
					}
					else
					{
						Console.WriteLine("Данный водитель не совершил ни одного нарушения");
					}
				}
				else
				{
					Console.WriteLine("Водителя с выбранным вами идентификатором не существует в базе данных");
				}
			}
		}
	}
}
