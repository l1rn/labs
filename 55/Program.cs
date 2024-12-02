using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab55.Flat;

namespace lab55
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flat[] flats = new Flat[]
            {
                new Flat(1001, 40, 4, 40000, 10000),
                new GovernmentFlat(1002, 50, 3, 45000, 10000, 60000),
                new PrivatizeFlat(1003, 60, 2 , 60000, 10000, 30000)
            };
            int reply = -1;
            while (reply != 3)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("|1 - вывод информации       |");
                Console.WriteLine("|2 - поиск по лицевому счету|");
                Console.WriteLine("|3 - выйти из программы     |");
                Console.WriteLine("-----------------------------");
                if (!int.TryParse(Console.ReadLine(), out reply))
                {
                    Console.WriteLine("Ошибка! Вы неправильно ввели.");
                }
                switch (reply)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Информация о всех квартирах:");
                        foreach(var flat in flats)
                        {
                            flat.PrintAllInfo();
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите лицевой счет для поиска: ");
                        if (!long.TryParse(Console.ReadLine(), out long searchAccount))
                        {
                            Console.WriteLine("Ошибка: введите корректный лицевой счет.");
                            break;
                        }

                        Flat foundFlat = null;
                        foreach (var flat in flats)
                        {
                            if (flat.GetPersonalAccount() == searchAccount)
                            {
                                foundFlat = flat;
                                break;
                            }
                        }

                        if (foundFlat != null)
                        {
                            Console.WriteLine("Найдена квартира:");
                            foundFlat.PrintAllInfo();
                        }
                        else
                        {
                            Console.WriteLine("Квартира с указанным лицевым счетом не найдена.");
                        }
                        break;
                    case 3:
                        break;
                }
                
            }


        }


    }
}
