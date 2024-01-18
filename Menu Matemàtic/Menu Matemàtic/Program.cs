using System.Drawing;
using System.Net.NetworkInformation;

namespace Menu_Matemàtic
{
    internal class Program
    {
        private static ConsoleColor originalForegroundColor;
        private static ConsoleColor originalBackgroundColor;

        static void Main(string[] args)
        {
            // Definim variables
            char opcio;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Benvingut al menu matemàtic!");
            Console.ResetColor();
            
            opcio = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (opcio)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Entra el primer número");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entra el segon número");
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    int maxim = MaximCalcul(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"El numero més gran entre {num1} i {num2} és {maxim}");
                    Return();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Entra el primer número");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entra el segon número");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    int resultat = MCDCalcul(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"El MCD de  {num1} i {num2} és {resultat}");
                    Return();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Entra el primer número");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Entra el segon número");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    resultat = MCMCalcul(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"El MCM de  {num1} i {num2} és {resultat}");
                    Return();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Entra un número");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    resultat = FactorialCalcul(num1);
                    Console.Clear();
                    Console.WriteLine($"El factorial de {num1} és {resultat}");
                    break;
                case '5':
                    Console.WriteLine("Escriu dos numeros dels que es faran una operacio combinatoria");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriu el segon numero");
                    num2 = Convert.ToInt32(Console.ReadLine());

                    Combinatori(num1, num2);

                    Console.WriteLine(Combinatori(num1, num2));

                    break;
                case '6':
                    Console.WriteLine("Escriu un numero del que es buscara el seu divisor major");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    DivisorMajor(num1);

                    Console.WriteLine(DivisorMajor(num1));

                    break;
                case '7':
                    Console.WriteLine("Escriu un numero del que es veura si es primer");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    Primer(num1);

                    Console.WriteLine(Primer(num1));

                    break;
                case '8':
                    Console.WriteLine("Escriu el nombre de primers numeros primers que vols veure");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    Nprimers(num1);

                    Console.WriteLine(Nprimers(num1));

                    break;
                case 'q':
                    Console.WriteLine("Adéu");
                    break;
                default:
                    Console.WriteLine("Introdueix un valor correcte");
                    break;
            }
        }

        static void Return()
        {
            int i = 5;
            while (i != 0)
            {
                Console.Write("\r");
                Console.Write($"Tornant al menu : {i}s");
                Thread.Sleep(1000);
                i--;
            }
        }
        static int MaximCalcul(int num1, int num2)
        {
            int nummaxim = 0;
            if (num1 > num2)
            {
                nummaxim = num1;

            }
            else if (num2 > num1)
            {
                nummaxim = num2;
            }

            return nummaxim;
        }

        static int MCDCalcul(int num1, int num2)
        {
            while (num2 != 0)
            {
                int resultat = num2;
                num2 = num1 % num2;
                num1 = resultat;
            }
            return num1;
        }

        static int MCMCalcul(int num1, int num2)
        {
            return (num1 * num2) / MCDCalcul(num1, num2);
        }

        static int FactorialCalcul(int num1)
        {
            int resultat = 1;
            for (int i = 1; i <= num1; i++)
            {
                resultat *= i;
            }
            return resultat;
        }
        static int Combinatori(int num, int num2)
        {
            int resultatfinal = 0;
            resultatfinal = FactorialCalcul(num) / (FactorialCalcul(num2) * FactorialCalcul(num - num2));
            return resultatfinal;
        }
        static int DivisorMajor(int num)
        {
            int divisormajor = 0;
            for (int i = 1; i != num; i++)
            {
                if (num % i == 0)
                {
                    divisormajor = i;
                }
            }
            return divisormajor;
        }
        static bool Primer(int num1)
        {
            bool primer = true;
            for (int i = 2; i != num1; i++)
            {
                if (num1 % i == 0)
                {
                    primer = false;
                }
            }
            return primer;
        }

        static string Nprimers(int num1)
        {
            int i = 1;
            int contadorprimers = 0;
            int contador = 0;
            string llista = "";
            while (contadorprimers != num1)
            {
                for (int n = 1; n <= i; n++)
                {
                    if ((i % n) == 0)
                    {
                        contador++;
                    }
                }
                if (contador == 2)
                {
                    llista = llista + i + ",";
                    contadorprimers++;
                }
                contador = 0;
                i++;
            }
            return llista;
        }
    }
}

