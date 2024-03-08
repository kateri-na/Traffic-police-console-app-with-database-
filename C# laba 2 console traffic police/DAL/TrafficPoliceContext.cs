using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__laba_2_console_traffic_police.Models;
using Microsoft.EntityFrameworkCore;

namespace C__laba_2_console_traffic_police.DAL
{
	public class TrafficPoliceContext: DbContext
	{
		public DbSet<Driver> Drivers { get; set; } = null!;
		public DbSet<DriverLicence> DriversLicences { get; set; } = null!;
		public DbSet<Mark> Marks { get; set; } = null!;
		public DbSet<Model> Models { get; set; } = null!;
		public DbSet<Penalty> Penalties { get; set; } = null!;
		public DbSet<Vehicle> Vehicles { get; set; } = null!;
		public DbSet<Violation> Violations { get; set; } = null!;

		public TrafficPoliceContext()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
										Database = TrafficPoliceDB;
										Trusted_Connection = true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Model>().HasOne(e => e.mark).WithMany(e => e.models)
			//	.HasForeignKey(e => e.MarkId).IsRequired();
			//modelBuilder.Entity<Vehicle>().HasOne(e => e.model).WithMany(e => e.vehicles)
			//	.HasForeignKey(e => e.ModelID).IsRequired();
			//modelBuilder.Entity<Driver>().HasMany(e => e.vehicles).WithOne(e => e.driver)
			//	.HasForeignKey(e => e.DriverID).IsRequired();
			//modelBuilder.Entity<Driver>().HasOne(e => e.driverLicence).WithOne(e => e.driver)
			//	.HasForeignKey<Driver>(e => e.driverLicenceID).IsRequired();
			//modelBuilder.Entity<DriverLicence>().HasMany(e => e.penalties).WithOne(e => e.driverLicence)
			//	.HasForeignKey(e => e.DriverLicenceID).IsRequired();
			//modelBuilder.Entity<Penalty>().HasOne(e => e.violation).WithMany(e => e.penalties)
			//	.HasForeignKey(e => e.violationID).IsRequired();

			modelBuilder.Entity<Mark>().HasData(
				new Mark() { MarkId = 1, MarkName = "Fiat" },
				new Mark() { MarkId = 2, MarkName = "Citroen" },
				new Mark() { MarkId = 3, MarkName = "Chevrolet" },
				new Mark() { MarkId = 4, MarkName = "Hyundai" }
				);

			modelBuilder.Entity<Model>().HasData(
				new Model() { ModelId = 1, ModelName = "Sedici", MarkId = 1},
				new Model() { ModelId = 2, ModelName = "C8", MarkId = 2 },
				new Model() { ModelId = 3, ModelName = "C3 Pluriel", MarkId = 2 },
				new Model() { ModelId = 4, ModelName = "Epica", MarkId = 3 },
				new Model() { ModelId = 5, ModelName = "Accent", MarkId = 4 }
				);

			modelBuilder.Entity<DriverLicence>().HasData(
				new DriverLicence() { DriverLicenceId = 1, BirthDate = "1994-12-13", PlaceOfBirth = "Россия, г. Майкоп", 
					IssueDate = "2022-12-26", ExpirationDate = "2032-12-26", IssuingAuthority = "ГИБДД 1179009" },
				new DriverLicence() { DriverLicenceId = 2, BirthDate = "1960-10-21", PlaceOfBirth = "Россия, г. Владимир",
					IssueDate = "2020-02-19", ExpirationDate = "2030-02-19", IssuingAuthority = "ГИБДД 1117110" },
				new DriverLicence() { DriverLicenceId = 3, BirthDate = "1980-04-07", PlaceOfBirth = "Россия, г. Воронеж", 
					IssueDate = "2020-06-04", ExpirationDate = "2030-06-03", IssuingAuthority = "ГИБДД 1120931" },
				new DriverLicence() { DriverLicenceId = 4, BirthDate = "1974-11-10", PlaceOfBirth = "Россия, г. Нижневартовск",
					IssueDate = "2017-03-08", ExpirationDate = "2027-03-08", IssuingAuthority = "ГИБДД 1162048" },
				new DriverLicence() { DriverLicenceId = 5, BirthDate = "1989-02-28", PlaceOfBirth = "Россия, г. Чебоксары",
					IssueDate = "2013-11-11", ExpirationDate = "2023-11-11", IssuingAuthority = "ГИБДД 1197031" }
				);

			modelBuilder.Entity<Vehicle>().HasData(
				new Vehicle() { VIN = "ZJ2ZX077601548459", LicencePlateNumber = "У102ТО31", Color = "Серебристо-коричневый", 
					ManufactureYear = 2010, RegistrationDate = "2010-02-14", DeregistrationDate = "2015-10-16", ModelID = 2, DriverID =3 },
				new Vehicle() { VIN = "ZZ4RK753684879518", LicencePlateNumber = "О897ХТ70", Color = "Сине-фиолетовый", 
					ManufactureYear = 2008, RegistrationDate = "2011-08-21", DeregistrationDate = "2022-09-17", ModelID = 1, DriverID = 2 },
				new Vehicle() { VIN = "PW2GV785928208889", LicencePlateNumber = "Н016КО10", Color = "Серебристо-бежевый", 
					ManufactureYear = 2009, RegistrationDate = "2019-02-16", ModelID =3, DriverID = 4 }, 
				new Vehicle() { VIN = "TW9EH264781492773", LicencePlateNumber = "К245ОХ50", Color = "Белый", 
					ManufactureYear = 2007, RegistrationDate = "2016-03-04", DeregistrationDate = "2020-12-15", ModelID = 4, DriverID = 5 },
				new Vehicle() { VIN = "EH0GR082270787581", LicencePlateNumber = "Т073НЕ31", Color = "Серебристо-ярко-фиолетовый", 
					ManufactureYear = 2020, RegistrationDate = "2020-07-17", ModelID = 5, DriverID = 1 }
				);

			modelBuilder.Entity<Driver>().HasData(
				new Driver() { DriverId = 1, DriverSurname= "Содовский", DriverName = "Семен", DriverMiddleName = "Кириллович", 
					DriverAddress = "Россия, г. Майкоп, Новый пер., д. 20 кв.116", DriverPhoneNumber = "+7 (966) 457-70-80", 
					driverLicenceID = 1
				},
				new Driver() { DriverId = 2, DriverSurname = "Гунина", DriverName = "Марианна", DriverMiddleName = "Трофимовна",
					DriverAddress = "Россия, г. Владимир, Березовая ул., д. 20 кв.208", DriverPhoneNumber = "+7 (946) 384-70-82",
					driverLicenceID = 2
				},
				new Driver() { DriverId = 3, DriverSurname = "Касьяненко", DriverName = "Денис", DriverMiddleName = "Евгениевич",
					DriverAddress = "Россия, г. Воронеж, Полевая ул., д. 4 кв.39", DriverPhoneNumber = "+7 (959) 640-62-77",
					driverLicenceID = 3
				},
				new Driver() { DriverId = 4, DriverSurname = "Сабитова", DriverName = "Алиса", DriverMiddleName = "Федоровна",
					DriverAddress = "Россия, г. Нижневартовск, Речной пер., д. 17 кв.180", DriverPhoneNumber = "+7 (924) 239-79-35",
					driverLicenceID = 4
				},
				new Driver() { DriverId = 5, DriverSurname = "Содовский", DriverName = "Данила", DriverMiddleName = "Ипполитович",
					DriverAddress = "Россия, г. Чебоксары, Партизанская ул., д. 8 кв.122", DriverPhoneNumber = "+7 (938) 801-86-28",
					driverLicenceID = 5
				}
				);

			modelBuilder.Entity<Violation>().HasData(
				new Violation() { ViolationId = 1, Fine = 1000, 
					ViolationType = "Управление транспортным средством водителем, не пристегнутым ремнем безопасности" },
				new Violation() { ViolationId = 2, Fine = 30000,
					ViolationType = "Управление транспортным средством водителем, находящимся в состоянии опьянения" },
				new Violation() { ViolationId = 3, Fine = 1500, 
					ViolationType = "Превышение установленной скорости движения транспортного средства на величину от 41 до 60 км/ч включительно" },
				new Violation() { ViolationId = 4, Fine = 1000,
					ViolationType = "Проезд на запрещающий сигнал светофора или на запрещающий жест регулировщика" },
				new Violation() { ViolationId = 5, Fine = 500, 
					ViolationType = "Непредоставление преимущества в движении маршрутному транспортному средству"}
				);
			modelBuilder.Entity<Penalty>().HasData(
				new Penalty() { PenaltyId = 1, Date = "2021-08-17", Time = "20:38", District = "Ленинский район", violationID = 2, DriverLicenceID = 1},
				new Penalty() { PenaltyId = 2, Date = "2023-11-03", Time = "7:41", District = "Советский район", violationID = 4, DriverLicenceID = 2 },
				new Penalty() { PenaltyId = 3, Date = "2005-12-31", Time = "19:33", District = "Коминтерновский район", violationID = 3, DriverLicenceID = 3 },
				new Penalty() { PenaltyId = 4, Date = "2017-09-16", Time = "14:12", District = "Центральный район", violationID = 1, DriverLicenceID = 4 },
				new Penalty() { PenaltyId = 5, Date = "2022-07-15", Time = "6:15", District = "Советский район", violationID = 5, DriverLicenceID = 2
				});

			base.OnModelCreating(modelBuilder);
		}
	}
}
