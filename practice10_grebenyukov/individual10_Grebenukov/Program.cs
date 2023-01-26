using System;

namespace individual10_Grebenukov
{
    class Program
    {
        static void Main(string[] args)
        {
            static int CheckingForLengthArray(int number)
            {
                
                while (true)
                {
                    if (number < 5)
                    {
                        Console.WriteLine("Введите число больше или равно 5");
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
            static double[,] Input()
            {
                Console.WriteLine("Введите количество строк массива: ");
                int line = CheckingForANumber();
                line = CheckingForLengthArray(line);
                Console.WriteLine("Введите количество столбцов массива: ");
                int column = CheckingForANumber();
                column = CheckingForLengthArray(column);
                double[,] Myarray = new double[line, column];
                Random rand = new Random();
                for (int i = 0; i < Myarray.GetLength(0); i++)
                {
                    for (int j = 0; j < Myarray.GetLength(1); j++)
                    {
                        while (true)
                        {

                            try
                            {
                                Console.Write("Введите число:  ");
                                Myarray[i, j] = Convert.ToDouble(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число");
                            }
                        }

                    }
                }
                return Myarray;
            }
            static void  Output(double[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i,j], 5}   ");
                    }
                    Console.WriteLine();
                }
                
            }
            static double Zadanie1(double[,] array)
            {
                double summ = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 1; j < 2; j++)
                    {
                        if(array[i,j] > 10)
                        {
                            summ += array[i, j];
                        }
                    }
                }
                return summ;
            }
            static int Zadanie2(double[,] array)
            {
                int count = 0;
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] != 0)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            static double Zadanie3(double[,] array)
            {
                double summ = 0;
                for (int i = 4; i < 5; i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] < 0)
                        {
                            summ += array[i, j];
                        }
                    }
                }
                return summ;
            }
            double[,] myarray = Input();
            Output(myarray);
            Console.WriteLine("Сумма элементов второго столбца массива, больших 10 = " + Zadanie1(myarray));
            Console.WriteLine("Количество ненулевых элементов первой строки массива = " + Zadanie2(myarray));
            Console.WriteLine("Сумма отрицательных элементов пятой строки массива = " + Zadanie3(myarray));


        }
    }
}
