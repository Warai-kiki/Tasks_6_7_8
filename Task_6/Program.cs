using System;

namespace Task_6
{
    class Creation_Massiv
    {
        private int length;
        private int heigth;

        public int Length
        {
            get { return length; }
            set
            {
                length = value;
            }
        }
        public int Heigth
        {
            get { return heigth; }
            set { heigth = value; }
        }

        public int[,] Creation(int l = 0, int h = 0)
        {
            Random rnd = new Random();
            int[,] matrix = new int[h, l];
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(0, 41);
                }
            };
            Console.WriteLine("\nПочатковий масив:");
            PrintMassiv(matrix);
            return matrix;
        }
        
        public void PrintMassiv(int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        
    }
    class Program
    {
        static void Finding_nums(int x, int [,] m)
        {
            int rows = m.GetUpperBound(0) + 1;
            int columns = m.Length / rows;
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (m[i, j] == x)
                    {
                        Console.WriteLine($"Введене Вами число {x} є в масиві на місці: рядок-{i+1}; стовпчик-{j+1})");
                        counter++;
                    }
                }
                Console.WriteLine();
            }
            if (counter == 0)
                Console.WriteLine("Такого єлемента немає в масиві");
        }

        static void Special_Arifmetic(int[,] ono)
        {
            int rows = ono.GetUpperBound(0) + 1;
            int columns = ono.Length / rows;
            int sum = 0;
            for (int j = 0; j < columns; j++)
            {
                sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    try
                    {
                        sum += ono[i,j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Щось пішло не так.");
                        Environment.Exit(1);
                    }
                }
                double sum_conv = Convert.ToDouble(sum);
                double arifmetic = sum_conv  / rows;
                Console.WriteLine($"Середнє арифметичне {j+1}-го стовпчика : " + arifmetic);
            }
        } 

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Console.InputEncoding = System.Text.Encoding.Unicode;

            Creation_Massiv our_massiv = new Creation_Massiv();

            Console.WriteLine("Введіть кількість стрічок: ");
            int heigth;
            while (true)
            {
                try
                {
                    string heigth_1use = Console.ReadLine();
                    heigth = Convert.ToInt32(heigth_1use);
                    if (heigth < 1)
                    {
                        Console.WriteLine("Потрібне натуральне число. Повторіть спробу.");
                    }
                    else
                        break; ;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Щось пішло не так. Спробуйте ще раз.");
                }
            }
            our_massiv.Heigth= heigth;

            Console.WriteLine("Введіть кількість стовпців: ");
            int length;
            while (true)
            {
                try
                {
                    string length_1use = Console.ReadLine();
                    length = Convert.ToInt32(length_1use);
                    if (length < 1)
                    {
                        Console.WriteLine("Потрібне натуральне число. Повторіть спробу.");
                    }
                    else
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Щось пішло не так. Спробуйте ще раз.");
                }
            }
            our_massiv.Length = length;

            int [,] massiv = our_massiv.Creation(our_massiv.Length, our_massiv.Heigth);

            Console.WriteLine("\nВведіть число. яке хочете знайти в масиві: ");
            int key;
            while (true)
            {
                try
                {
                    string key_1use = Console.ReadLine();
                    key = Convert.ToInt32(key_1use);
                    if (0 <= key && key <= 40)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Таке число ви не знайдете в масиві.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Щось пішло не так. Спробуйте ще раз.");
                }
            }
            Finding_nums(key, massiv);

            Special_Arifmetic(massiv);

            Console.ReadKey();
        }
    }
}
