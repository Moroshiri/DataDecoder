using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDecoder
{
    internal class Measurement
    {
        public bool Sign; // Znak +/-
        public byte[] Digit; // Tablica cyfr
        public float Value; // Wartość zmierzona
        public string Format; // Rodzaj pomiaru
        public byte Range; // Zakres pomiarowy
        public string Type; // Rodzaj AC/DC
        public byte Dimension; // Mierzona wielkość V/A
        
        public Measurement(string[] args)
        {
            Digit = new byte[4];
            Parse(args);
        }

        public void Parse(string[] args)
        {
            if (args.Length < 9)
                throw new BadInputException();
            else
            {
                foreach (string element in args)
                {
                    if (element.Length > 2)
                        throw new BadInputException();
                }

                byte[] numArgs = new byte[9];

                for (int i = 0; i < 9; i++)
                {
                    numArgs[i] = Convert.ToByte(args[i], 16);
                }

                Sign = numArgs[0] != 0;

                Range = numArgs[6];
                for (int i = 1; i <= 4; i++)
                {
                    Digit[i - 1] = numArgs[i];
                    Value += Digit[i - 1] * (float)Math.Pow(10, - 4 + Range + i);
                }

                // Określanie formatu
                switch(numArgs[5])
                {
                    case 0:
                        {
                            Format = "V DC";
                            Value *= 0.1f;
                            break;
                        }
                    case 1:
                        {
                            Format = "V AC";
                            Value *= 0.1f;
                            break;
                        }
                    case 2:
                        {
                            Format = "mA DC";
                            break;
                        }
                    case 3:
                        {
                            Format = "mA AC";
                            break;
                        }
                    case 4:
                        {
                            Format = "Ohm";
                            Value *= 0.00001f;
                            break;
                        }
                    case 6:
                        {
                            Format = "V (Dioda)";
                            Value *= 0.1f;
                            break;
                        }
                    case 8:
                        {
                            Format = "A DC";
                            Value *= 10.0f;
                            break;
                        }
                    case 9:
                        {
                            Format = "A AC";
                            Value *= 10.0f;
                            break;
                        }
                    case 12:
                        {
                            Format = "uF";
                            break;
                        }
                    default:
                        {
                            throw new FormatException();
                        }
                }
                
            }
        }
        
    }
}
