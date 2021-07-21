using System;
using System.Collections.Generic;
using static System.Console;
using System.Globalization;

namespace ConsoleApp2
{
    class Birtday_boy
    {
        public string name { get; set; } = "NN";
        public DateTime date{ get; set; } = DateTime.Today;

        public override string ToString()
        {
            return name + " " + date;
        }
    }

    static class Ex
    {
        static public void Print(this List<Birtday_boy> list)
        {
            foreach (var el in list)
            {
                Write(el + "\n");
            }
            WriteLine();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Birtday_boy> list = new List<Birtday_boy>();
            int choice, index;
            string fullname;
            int day=0, month=0, year=0;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Вас приветствует программа ПОЗДРАВЛЯТОР. Пожалуйста, выберете функцию:");

            do
            {
                Console.WriteLine("1. Вывести список именинников на экран");
                Console.WriteLine("2. Добавить именинника");
                Console.WriteLine("3. Изменить данные об имениннике");
                Console.WriteLine("4. Удалить именинника");
                Console.WriteLine("5. Вывести на экран ближайших именинников на сегодня");
                Console.WriteLine("6. Выход из программы");
                
                do
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.Write("Ваш выбор?");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if ((choice < 1) || (choice > 6))
                        Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите ввод.");
                }
                while ((choice < 1) || (choice > 6));

                switch(choice)
                {
                    case 1: list.Print(); break;
                    case 2:
                        {
                            Console.Write("Введите имя именинника: ");
                            fullname = Console.ReadLine();
                            
                            Console.WriteLine("Введите дату рождения.");
                            do
                            {
                                Console.Write("Год: ");
                                year = Convert.ToInt32(Console.ReadLine());
                                if ((year < 1) || (year > 2021))
                                    Console.WriteLine("Неверный ввод года рождения. Введите корректные данные.");
                            }
                            while ((year < 1) || (year > 2021));

                            do
                            {
                                Console.Write("Месяц: ");
                                month = Convert.ToInt32(Console.ReadLine());
                                if ((month < 1) || (month > 12))
                                    Console.WriteLine("Неверный ввод месяца рождения. Введите корректные данные.");
                            }
                            while ((month < 1) || (month > 12));

                            int err=0;
                            do
                            {
                                err = 0;
                                Console.Write("День: ");
                                day = Convert.ToInt32(Console.ReadLine());
                                if ((day < 1) || (day > 31)) err++;
                                if ((month % 2 == 0) && (day == 31)) err++;
                                if (month == 2)
                                {
                                    if (year % 4 == 0)
                                    {
                                        if (day > 29) err++;
                                    }
                                    else if (day > 28) err++;
                                }
                                if (err>0)
                                    Console.WriteLine("Неверный ввод дня рождения. Введите корректные данные.");
                            }
                            while (err > 0);

                            list.Add(new Birtday_boy() { name = fullname, date = new DateTime(year, month, day) });
                            break;
                        }
                    case 3:
                        {
                            int err=0;
                            int c;
                            do
                            {
                                err = 0;
                                Console.Write("Введите имя редактируемого именинника: ");
                                fullname = Console.ReadLine();
                                if (!(list.Exists(x => x.name == fullname)))
                                {
                                    err++;
                                    Console.WriteLine("Такого именинника нет. Повторите ввод.");
                                }
                            }
                            while (err!=0);

                            index = list.FindIndex(x => x.name == fullname);
                            do
                            {
                                Console.WriteLine("Желаете изменить имя? (1-да, 0-нет)");
                                c = Convert.ToInt32(Console.ReadLine());
                                if ((c < 0) || (c > 1)) Console.WriteLine("Некорректные данные. Повторите ввод.");
                            }
                            while ((c < 0) || (c > 1));

                            if (c==1)
                            {
                                Console.Write("Введите новое имя: ");
                                fullname = Console.ReadLine();
                                list[index].name = fullname;
                            }

                            do
                            {
                                Console.WriteLine("Желаете изменить дату? (1-да, 0-нет)");
                                c = Convert.ToInt32(Console.ReadLine());
                                if ((c < 0) || (c > 1)) Console.WriteLine("Некорректные данные. Повторите ввод.");
                            }
                            while ((c < 0) || (c > 1));

                            if (c == 1)
                            {
                                Console.WriteLine("Введите дату рождения.");
                                do
                                {
                                    Console.Write("Год: ");
                                    year = Convert.ToInt32(Console.ReadLine());
                                    if ((year < 1) || (year > 2021))
                                        Console.WriteLine("Неверный ввод года рождения. Введите корректные данные.");
                                }
                                while ((year < 1) || (year > 2021));

                                do
                                {
                                    Console.Write("Месяц: ");
                                    month = Convert.ToInt32(Console.ReadLine());
                                    if ((month < 1) || (month > 12))
                                        Console.WriteLine("Неверный ввод месяца рождения. Введите корректные данные.");
                                }
                                while ((month < 1) || (month > 12));

                                do
                                {
                                    err = 0;
                                    Console.Write("День: ");
                                    day = Convert.ToInt32(Console.ReadLine());
                                    if ((day < 1) || (day > 31)) err++;
                                    if ((month % 2 == 0) && (day == 31)) err++;
                                    if (month == 2)
                                    {
                                        if (year % 4 == 0)
                                        {
                                            if (day > 29) err++;
                                        }
                                        else if (day > 28) err++;
                                    }
                                    if (err > 0)
                                        Console.WriteLine("Неверный ввод дня рождения. Введите корректные данные.");
                                }
                                while (err > 0);
                            }

                            list[index].date = new DateTime(year, month, day);

                            Console.WriteLine("Данные обновлены.");
                            break;
                        }
                    case 4:
                        {
                            int err = 0;
                            do
                            {
                                err = 0;
                                Console.Write("Введите имя удаляемого именинника: ");
                                fullname = Console.ReadLine();
                                if (!(list.Exists(x => x.name == fullname)))
                                {
                                    err++;
                                    Console.WriteLine("Такого именинника нет. Повторите ввод.");
                                }
                            }
                            while (err != 0);

                            index = list.FindIndex(x => x.name == fullname);
                            list.Remove(list[index]);

                            Console.WriteLine("Удаление завершено.");
                            break;
                        }
                    case 5:
                        {
                            int datetoday, bufferdate;
                            int min = 1000, minindex = -1;
                            datetoday = (DateTime.Today).DayOfYear;
                            int i = 0;
                            foreach(Birtday_boy bb in list)
                            {
                                bufferdate = bb.date.DayOfYear;
                                if (Math.Abs(datetoday-bufferdate) < min)
                                {
                                    min = Math.Abs(datetoday - bufferdate);
                                    minindex = i;
                                }
                                i++;
                            }

                            Console.WriteLine("Ближайший день рождения: {0}", list[minindex]);
                            break;
                        }
                    case 6:
                        {
                            WriteLine("-----------------------------------------------------");
                            WriteLine("Спасибо, что воспользовались нашей программой!");
                            WriteLine("-----------------------------------------------------");
                            break;
                        }
                }
                
            }
            while (choice != 6);
        }
    }
}