using C__laba_2_console_traffic_police.DAL;
using C__laba_2_console_traffic_police.Models;

namespace C__laba_2_console_traffic_police {
	public class Programm
	{
		public static void Main(string[] args)
		{
            Menu.StartStep();
            bool wantToContinue = true;
			while (wantToContinue)
			{
				Console.WriteLine("Выберите пункт меню:");
				Console.WriteLine("1.Зарегистрировать транспортное средство и внести его в реестр:");
				Console.WriteLine("2.Снять с регистрации транспортное средство");
				Console.WriteLine("3.Запросить информацию о правонарушениях водителя");
				string choise = Console.ReadLine();
				choise = choise.Trim();
				switch (choise)
				{
					case "1":
						Menu.FirstStep();
						break;
					case "2":
						Menu.SecondStep();
						break;
					case "3":
						Menu.ThirdStep();
						break;
					default:
						Console.WriteLine("Введенный вами пункт не содержится в меню");
						break;
				}
                Console.WriteLine("Вы желаете выйти из программы? Д - да, любая другая клавиша - нет");
                string desicion = Console.ReadLine();
                desicion.Trim();
                if (desicion == "Д" || desicion == "д")
                    wantToContinue = false;
            }
		}

	}
}