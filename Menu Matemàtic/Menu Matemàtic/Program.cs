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
            Console.WriteLine("1. Màxim");
            Console.WriteLine("2. MCD");
            Console.WriteLine("3. MCM");
            Console.WriteLine("4. Factorial");
            Console.WriteLine("5. Combinatori");
            Console.WriteLine("6. MostrarDivisorMajor");
            Console.WriteLine("7. EsPrimer");
            Console.WriteLine("8. NPrimersPrimers");
            Console.WriteLine("q. Sortir");
            Console.Write("Entra un valor: ");
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
                    Console.Clear();
                    Console.WriteLine("Escriu dos numeros dels que es faran una operacio combinatoria");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriu el segon numero");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    resultat = Combinatori(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"El combinatori de  {num1} i {num2} és {resultat}");
                    Return();

                    break;
                case '6':
                    Console.Clear();
                    Console.WriteLine("Escriu un numero del que es buscara el seu divisor major");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    resultat = DivisorMajor(num1);
                    Console.Clear();
                    Console.WriteLine($"El divisor major de {num1} és {resultat}");
                    Return();
                    break;
                case '7':
                    Console.Clear();
                    Console.WriteLine("Escriu un numero del que es veura si es primer");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    string esprimer = Primer(num1);
                    Console.WriteLine($"El numero {num1} {esprimer} és primer");
                    Return();
                    break;
                case '8':
                    Console.Clear();
                    Console.WriteLine("Escriu el nombre de primers numeros primers que vols veure");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    string primers = Nprimers(num1);
                    Console.Clear();
                    Console.WriteLine($"Els {num1} numeros primers són {primers}");
                    Return();
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
        static string Primer(int num1)
        {
            bool primer = true;
            string resultat = "";
            for (int i = 2; i != num1; i++)
            {
                if (num1 % i == 0)
                {
                    primer = false;
                }
            }
            if (primer == false)
            {
                resultat = "NO";
            }
            else if (primer == true)
            {
                resultat = "SI";
            }
            return resultat;
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

