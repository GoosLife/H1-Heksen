 using System;

namespace H1_Heksen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HexChecker hc = new HexChecker();

            HexValidity hv;

            do
            {
                Console.Clear();

                Console.WriteLine("Input your hex value: ");
                string potentialHex = Console.ReadLine();

                hv = hc.Check(potentialHex);

                switch (hv)
                {
                    case HexValidity.MISSING_HASH:
                        Console.WriteLine("\nPlease begin your hex value with the # symbol.\n");
                        break;
                    case HexValidity.INCORRECT_LENGTH:
                        Console.WriteLine("\nPlease input exactly 7 characters, including the leading #\n");
                        break;
                    case HexValidity.INVALID_INPUT:
                        Console.WriteLine("\nPlease only use the characters 0-9 and A-F\n");
                        break;
                    case HexValidity.VALID:
                        Console.WriteLine("\nYour hex value was correct.\n");
                        break;
                }
                Console.WriteLine("Press any key to continue . . . ");
                Console.ReadKey();
            } while (hv != HexValidity.VALID);
        }
    }
}