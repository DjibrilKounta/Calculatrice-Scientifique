namespace Calculatrice_Scientifique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            Menu();
        }


        static void Welcome()
        {
            Console.WriteLine("   ____      _            _       _        _           \r\n  / ___|__ _| | ___ _   _| | __ _| |_ _ __(_) ___ ___  \r\n | |   / _` | |/ __| | | | |/ _` | __| '__| |/ __/ _ \\ \r\n | |__| (_| | | (__| |_| | | (_| | |_| |  | | (_|  __/ \r\n  \\____\\__,_|_|\\___|\\__,_|_|\\__,_|\\__|_|  |_|\\___\\___| \r\n / ___|  ___(_) ___ _ __ | |_(_)/ _(_) __ _ _   _  ___ \r\n \\___ \\ / __| |/ _ \\ '_ \\| __| | |_| |/ _` | | | |/ _ \\\r\n  ___) | (__| |  __/ | | | |_| |  _| | (_| | |_| |  __/\r\n |____/ \\___|_|\\___|_| |_|\\__|_|_| |_|\\__, |\\__,_|\\___|\r\n                                         |_|           ");
        }

        static void Menu()
        {
            Console.WriteLine("******************************\tMENU\t******************************");
            Console.WriteLine("**********\t1 - Addition");
            Console.WriteLine("**********\t2 - Soustraction");
            Console.WriteLine("**********\t3 - Multiplication");
            Console.WriteLine("**********\t4 - Division");
            Console.WriteLine("**********\t5 - Menu");
            Console.WriteLine("**********\t0 - Quitter");
            Console.WriteLine("**********************************************************************");
            Check();
        }

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b)
        {
            if(b == 0)
            {
                Console.WriteLine("Erreur : Division par zéro interdite !");
                return double.NaN;
            }
            else
            {
                return a / b;
            }
        }
        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("bye");
            Environment.Exit(0);
        }

        static void Check(int min = 0, int max = 5)
        {
            Console.WriteLine("tapez 1 pour l'addition, 2 pour la soustraction, 3 pour la multiplication,4 pour la division,5 revenir au menu et 0 pour quitter");
            int selector = -1;
            double nb1=0, nb2=0;
            bool nbsValid = false;

            while (selector < min || selector > max)
            {
                if (selector < min || selector > max)
                {
                    Console.WriteLine("vous devez choisir de " + min + "  à " + max);
                }
                try
                {
                    selector = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (selector < 5 && selector > 0)
            {
                Console.WriteLine("Saisir les 2 nombres");
                do
                {
                    try
                    {
                        nb1 = double.Parse(Console.ReadLine());
                        nb2 = double.Parse(Console.ReadLine());
                        nbsValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("il faut saisir des nombres");
                    }
                } while (!nbsValid);
                Direction(selector, nb1, nb2);
            }
            else
            {
                Direction(selector);
            }
            Check();
        }

        static void Direction(int selector, double a, double b)
        {
            double c = selector switch
            {
                1 => Add(a, b),
                2 => Subtract(a, b),
                3 => Multiply(a, b),
                4 => Divide(a, b),
                _ => 0
            };
            Console.WriteLine(c);
        }
        static void Direction(int selector)
        {
            switch (selector)
            {
                case 0: Exit(); break;
                case 5: Menu(); break;
            }
        }
    }
}
