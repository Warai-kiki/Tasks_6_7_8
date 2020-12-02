using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_7
{
    enum Weather_Type
    {
        Not_specified = 1,
        Rain,
        Short_term_rain,
        Snow,
        Fog,
        Gloomily,
        Sunny,
    };

    class WeatherParametersDay
    {
        private int num_of_days;
        private double day_temp;
        private double night_temp;
        private int atmos_tysk;
        private int opady;
        private Weather_Type wtype;

        public int Num_of_days
        {
            get
            {
                return num_of_days;
            }
            set
            {
                if (value > 0)
                    num_of_days = value;
            }
        }

        public double Day_temp
        {
            get
            {
                return day_temp;
            }
            set { day_temp = value; }
        }

        public double Night_temp
        {
            get { return night_temp; }
            set { night_temp = value; }
        }

        public int Atmos_tysk
        {
            get { return atmos_tysk; }
            set { atmos_tysk = value; }
        }

        public int Opady
        {
            get { return opady; }
            set
            {
                if (value < 0)
                    opady = 0;
                else
                    opady = value;
            }
        }
        public Weather_Type Wtype
        {
            get { return wtype; }
            set
            {
                wtype = (Weather_Type)value;
            }
        }
    }

    class WeathersDays
    {
        private WeatherParametersDay[] WeatherArray { get; }
        public WeathersDays(WeatherParametersDay[] Weather_mass)
        {
            WeatherArray = Weather_mass;
        }
        private int CountDays(params Weather_Type[] weatherType)
        {
            int days = 0;
            foreach (WeatherParametersDay day in WeatherArray)
                if (weatherType.Contains(day.Wtype))
                {
                    days += 1;
                }

            return days;
        }


        public int Gloomily_days()
        {
            int gloomy = CountDays(Weather_Type.Gloomily);
            return gloomy;
        }

        public int Days_with()
        {
            int days_with = CountDays(Weather_Type.Snow, Weather_Type.Rain, Weather_Type.Short_term_rain);
            return days_with;
        }

        public double Opady_middle()
        {
            double mid_o = 0;
            foreach (WeatherParametersDay day in WeatherArray)
            {
                mid_o += day.Opady;
            }
            double mid_opady = mid_o / Days_with();
            return mid_opady;
        }

        public void Print_needs()
        {
            Console.WriteLine($"\nВсього похмурих днів: {Gloomily_days()}\nВсього днів зв опадами: {Days_with()}\nСередня кількість опадів: {Opady_middle()}\n");
        }
    }

    class Program
    {
        private static string[] LineArray()
        {
            string[] line = Console.ReadLine().Split(' ');
            if (line.Length != 31)
            {
                Console.WriteLine("Хіба у травні стільки днів?");
                Environment.Exit(1);
            }
            return line;
        }
        private static int[,] Readin(ref int[,] days_file)
        {
            string[] lines = File.ReadAllLines(@"files\may.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(' ').Length != 31)
                {
                    Console.WriteLine($"Щось пішло не так. Перевірте дані з файлу. ");
                    Environment.Exit(1);
                }
                string[] tempArray = lines[i].Split(' ');
                for (int j = 0; j < tempArray.Length; j++)
                    while (!int.TryParse(tempArray[j], out days_file[i, j]))
                    {
                        Console.WriteLine("Щось пішло не так. Перевірте дані з файлу.");
                        Environment.Exit(1);
                    }
            }
            Print(days_file);
            return Checking(days_file);
        }
        private static int[,] Keyboard(ref int[,] days_massiv)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Введіть стрічку з даними: {i + 1}");
                string[] tempArray = LineArray();
                for (int j = 0; j < tempArray.Length; j++)
                    while (!int.TryParse(tempArray[j], out days_massiv[i, j]))
                    {
                        Console.WriteLine("You enter wrong value!");
                    }
            }
            Print(days_massiv);
            return Checking(days_massiv);
        }

        private static int[,] Checking(int[,] daysArray)
        {
            for (int i = 0; i < daysArray.GetLength(1); i++)
            {
                if (daysArray[4, i] < 0 || daysArray[4, i] > 7 || daysArray[3, i] < 0 || daysArray[2, i] < 0)
                {
                    Console.WriteLine("WE");
                    Environment.Exit(1);
                }
            }
            return daysArray;
        }
        private static void Print(int[,] days_array)
        {
            for (int i = 0; i < days_array.GetLength(0); i++)
            {
                for (int j = 0; j < days_array.GetLength(1); j++)
                {
                    Console.Write(days_array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Console.InputEncoding = System.Text.Encoding.Unicode;

            int[,] may_information = new int[5, 31];
            Console.WriteLine("Якщо хочете ввести суму самі, натисніть клавішу A.\nЯкщо хочете загрузити з файлу, натисніть клавішу B.");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.A:
                    Keyboard(ref may_information);
                    break;
                case ConsoleKey.B:
                    Readin(ref may_information);
                    break;
            }
            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[may_information.GetLength(1)];
            WeathersDays weatherDays = new WeathersDays(weatherParametersDays);
            Console.WriteLine($"\nВсього похмурих днів: {weatherDays.Gloomily_days()}\nВсього днів з опадами: {weatherDays.Days_with()}\nСередня кількість опадів: {weatherDays.Opady_middle()}");

        }
        
    }
}

