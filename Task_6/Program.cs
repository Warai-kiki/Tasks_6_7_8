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

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(0, 40);
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

            for (int i = rows - 1; i >= 0; i--)
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
        static int Checking_ints(string c)
        {
            int num;
            while (true)
            {
                try
                {
                    num = Convert.ToInt32(c);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Щось пішло не так. Спробуйте ще раз.");
                    continue;
                }
            }
            return num;
        }

        static int Nat_check(string z)
        {
            int needed_num;
            while (true)
            {
                needed_num = Checking_ints(z);
                if (needed_num < 1)
                {
                    Console.WriteLine("Потрібне натуральне число. Повторіть спробу.");
                }
                else
                    break;
            }
            return needed_num;
        }

        static int Dop_check(string y)
        {
            int new_y;
            while (true)
            {
                new_y = Checking_ints(y);
                if (0 <= new_y && new_y <= 40)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Таке число ви не знайдете в масиві.");
                }
            }
            return new_y;
        }

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
                        Console.WriteLine($"Введене Вами число {x} є в масиві на місці: ({i};{j})");
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
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < columns-1; j++)
                {
                    sum += ono[j, i];
                }
                double arifmetic = sum / rows;
                count++;
                Console.WriteLine($"Середнє арифметичне {i+1}-го стовпчика : " + arifmetic);
            }
        } 

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Console.InputEncoding = System.Text.Encoding.Unicode;

            Creation_Massiv our_massiv = new Creation_Massiv();

            Console.WriteLine("Введіть кількість стрічок: ");
            string heigth_1use = Console.ReadLine();
            int heigth = Nat_check(heigth_1use);
            our_massiv.Heigth= heigth;

            Console.WriteLine("Введіть кількість стовпців: ");
            string length_1use = Console.ReadLine();
            int length = Nat_check(length_1use);
            our_massiv.Length = length;

            int [,] massiv = our_massiv.Creation(our_massiv.Length, our_massiv.Heigth);

            Console.WriteLine("\nВведіть число. яке хочете знайти в масиві: ");
            string key_1use = Console.ReadLine();
            int final_key = Dop_check(key_1use);
            Finding_nums(final_key, massiv);

            Special_Arifmetic(massiv);

            Console.ReadKey();
        }
    }
}
