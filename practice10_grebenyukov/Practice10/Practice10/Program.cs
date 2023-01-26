using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using Microsoft.VisualBasic;

namespace Practice10
{
    class Program
    {
        static void Main(string[] args)
        {
            static int Proverka1(int number)
            {
                
                while (true)
                {
                    if(number <= 0)
                    {
                        Console.WriteLine("Введите число больше 0");
                        number = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        return number;
                    }
                }
            }

            static int CheckingForANumber()
            {
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out int number))
                    {
                        Console.WriteLine("Ошибка! Введите ЦЕЛОЕ число!");
                    }
                    else
                    {
                        return number;
                    }
                }
            }
            static string[,] Zad1()
            {
                Console.WriteLine("Введите количество работников: ");
                int n = CheckingForANumber();
                n = Proverka1(n);
                Console.WriteLine("Введите количество месяцев: ");
                int m = CheckingForANumber();
                m = Proverka1(m);
                string[,] myArray = new string[n+1, m+2];
                for (int i = 0; i < myArray.GetLength(0); i++)
                {
                    for (int j = 0; j < myArray.GetLength(1); j++)
                    {
                        if(i == 0)
                        {
                            if (j == 0)
                                myArray[i, j] = "  ";
                            else if (j == 1)
                                myArray[i, j] = "         Дата рождения  ";
                            else
                                myArray[i, j] = $"  {j - 1} месяц    ";
                        }
                        if (i > 0 & j == 0)
                            myArray[i, j] = $"{i} работник  ";
                        if (j == 1 & i > 0)
                        {
                            while (true)
                            {
                                try
                                {
                                    DateTime dt;
                                    Console.WriteLine($"Введите дату рождения {i} работника в формате 9/09/9999");
                                    dt = DateTime.Parse(Console.ReadLine());
                                    myArray[i, j] = dt.ToString("d MMM yyyy") + "     ";
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Вы ввели неправильно дату");
                                }
                            }
                        }
                        if(j > 1 & i > 0)
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine($"Введите зарплату {i} сотрудника за {j-1} месяц");
                                    int x = int.Parse(Console.ReadLine());
                                    myArray[i, j] = Convert.ToString(x + "       ");
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Вы ввели зарплату неверно");
                                }
                            }
                        }
                    }
                }
                return myArray;
            }
            static void Output(string[,] myArray)
            {
                for (int i = 0; i < myArray.GetLength(0); i++)
                {
                    for (int j = 0; j < myArray.GetLength(1); j++)
                    {
                        Console.Write(myArray[i,j]);
                    }
                    Console.WriteLine();
                }
            }
            static void Zad2(string[,] myArray)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введите номер сотрудника, чью зарплату хотите узнать");
                        
                        
                         int rabotnik = CheckingForANumber();
                        
                        
                        double salary = Convert.ToDouble(myArray[rabotnik, 2]);
                        for (int i = rabotnik; i < rabotnik + 1; i++)
                        {
                            for (int j = 2; j < myArray.GetLength(1); j++)
                            {
                                if (salary < Convert.ToDouble(myArray[i, j]))
                                    salary = Convert.ToDouble(myArray[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Наибольшая зарплата {rabotnik} сотрудника = {salary}");
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Возникла ошибка!");
                    }
                }
            }
            static void Zad4(DateTime data1, DateTime data2)
            {
                int days = (int)(data2 - data1).TotalDays;
                int holiday = 0;
                DateTime check = data1;
                do
                {
                    string mm = check.ToString("MM");
                    if (check.DayOfWeek == DayOfWeek.Saturday || check.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Console.Write($"{check.ToString("dd.MM.yyyy (dddd)")} - выходной день! ");
                        if(mm == "12" || mm == "01" || mm == "02")
                            Console.WriteLine("Зима");
                        else if(mm == "03" || mm == "04" || mm == "05")
                            Console.WriteLine("Весна");
                        else if(mm == "06" || mm == "07" || mm == "08")
                            Console.WriteLine("Лето");
                        else
                            Console.WriteLine("Осень");
                        holiday++;
                    }
                    else
                    {
                        Console.Write($"{check.ToString("dd.MM.yyyy (dddd)")} - рабочий день! ");
                        if (mm == "12" || mm == "01" || mm == "02")
                            Console.WriteLine("Зима");
                        else if (mm == "03" || mm == "04" || mm == "05")
                            Console.WriteLine("Весна");
                        else if (mm == "06" || mm == "07" || mm == "08")
                            Console.WriteLine("Лето");
                        else
                            Console.WriteLine("Осень");
                    }
                    check = check.AddDays(1.0);
                } while (check <= data2);

                Console.WriteLine("Количество выходных = " + holiday);
                Console.WriteLine("Количество рабочих дней = " + (days - holiday));
            }

            static void Zad5_1()
            {
                
                Console.WriteLine("Введите возраст от 1 до 99");
                int age = CheckingForANumber();
                while (true)
                {
                    if (age <= 0 || age > 99)
                    {
                        Console.WriteLine("Введите возраст от 1 до 99");
                        age = CheckingForANumber();
                    }
                    else
                    {
                        break;
                    }
                }

                if (age == 11 || age == 12 | age == 13 || age == 14 || age == 15)
                {
                    Console.WriteLine(age + " Лет");
                }
                else
                {
                    switch (age % 10)
                    {
                        case 1:
                            Console.WriteLine(age + " Год");
                            break;
                        case 2:
                        case 3:
                        case 4:
                            Console.WriteLine(age + " Года");
                            break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 0:
                            Console.WriteLine(age + " Лет");
                            break;
                    }
                }
                
                
            }

            static void Zad5_2()
            {
                while (true)
                {
                    try
                    {
                        //Console.WriteLine($"Введите дату в формате 09/09");

                        //DateTime data = DateTime.Parse(Console.ReadLine());
                        //Console.WriteLine(data.ToString("dd MMMM"));
                        Console.Write("Введите день: ");
                        string day = Console.ReadLine();
                        Console.Write("Введите месяц: ");
                        string month = Console.ReadLine();
                        string result = day + "/" + month;
                        DateTime data = DateTime.Parse(result);
                        Console.WriteLine(data.ToString("dd MMMM"));
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неправильно дату");
                    }
                }
            }
            string[,] myArray = Zad1();
            Output(myArray);
            Zad2(myArray);
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                Console.Write($"Введите дату, с которой составить график для {i + 1} сотрудника: ");
                DateTime data1 = DateTime.Parse(Console.ReadLine());
                DateTime data2 = data1.AddYears(1);
                Zad4(data1, data2);
            }
            Zad5_1();
            Zad5_2();

        }
    }
}
