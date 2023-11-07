using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDecoder
{
    public class BadInputException : Exception
    {
        public BadInputException() : base("Nieprawidłowe dane wejściowe\nPoprawne użycie: decode XX XX XX XX XX XX XX XX XX")
        { }
    }
    internal class Program
    {
        // wywołanie programu: decode XX XX XX XX XX XX XX XX XX
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Użycie: decode XX XX XX XX XX XX XX XX XX");
                }
                else
                {
                    Measurement measure = new Measurement(args);   

                    // Wypisanie wyników:
                    string sign = measure.Sign && measure.Format != "Ohm" ? "-" : string.Empty;
                    Console.WriteLine($"\n{sign}{measure.Value} {measure.Format}");

                    Console.ReadKey();
                }                
            }
            catch(BadInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd konwersji - niepoprawny format");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Błąd konwersji - liczba spoza zakresu");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Błąd programu:\n{ex.Message}");
            }
        }
    }
}
