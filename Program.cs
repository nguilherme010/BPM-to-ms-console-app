using System;


namespace bpm_to_ms
{
    class Program
    {
        static void Main()
        {   
            Console.Title = "BPM to ms";
            Início:
            Console.SetWindowSize(40, 2);
            bool valid = false;
            double bpm = 0;
            
            while (!valid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("BPM");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" to ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("ms");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nInput BPM: ");
                valid = double.TryParse(Console.ReadLine(), out bpm);
            }


            double quarter = 60000 / bpm;
            double whole = quarter * 4;
            double half = quarter * 2;
            double eigth = quarter / 2;
            double sixteenth = quarter / 4;
            double thirtysecond = quarter / 8;

            double[] divisions = {whole, half, quarter, eigth, sixteenth, thirtysecond};
            string[] nomes = {"Whole note: ", "Half note: ", "Quarter note: ", "8th note: ", "16th note: ", "32nd note: "};
            
            Console.WriteLine("Triplet? (true/false)");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            bool triplet = bool.Parse(Console.ReadLine());

            if (triplet == true)
            {
                goto ResultadoTriplet;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Dotted? (true/false)");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            bool dotted = bool.Parse(Console.ReadLine());
            if (dotted == true)
            {
                goto ResultadoDotted;
            }
            else
            {
                goto Resultado;
            }

            ResultadoTriplet:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetWindowSize(40, 9);
                Console.Write("Converting.");
                Timer(500);
                Console.Write(".");
                Timer(500);
                Console.Write(".");
                Timer(500);
                Console.Clear();

                Console.WriteLine("\n" + bpm + "BPM to ms:");
                for (int i = 0; i < 6; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(nomes[i]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Tripleter(divisions[i]) + "ms\n");
                }

                goto Ending;


            ResultadoDotted:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(40, 9);
            Console.Write("Converting.");
            Timer(500);
            Console.Write(".");
            Timer(500);
            Console.Write(".");
            Timer(500);
            Console.Clear();
            
            Console.WriteLine("\n" + bpm + "BPM to ms:");
            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(nomes[i]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Dotter(divisions[i]) + "ms\n");
            }
            goto Ending;


            Resultado:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(40, 9);
            Console.Write("Converting.");
            Timer(500);
            Console.Write(".");
            Timer(500);
            Console.Write(".");
            Timer(500);
            Console.Clear();

            Console.WriteLine("\n" + bpm + "BPM to ms:");
            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(nomes[i]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(divisions[i] + "ms\n");
            }
            

            Ending:
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPress <R> to restart, any other to exit.");
                if (Console.ReadKey().Key == ConsoleKey.R)
                {
                    Console.Clear();
                    goto Início;
                }
        }
        static double Tripleter(double d)
            {
                return (d*2)/3; 
            }

        static double Dotter(double u)
            {
                return u + (u/2);
            }

        static void Timer(int n)
        {
            System.Threading.Thread.Sleep(n);
        }
    }
}
