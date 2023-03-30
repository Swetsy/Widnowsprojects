using System;

namespace BoterKaasEnEieren
{
    class Program
    {
        static char[] pos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // 1 voor speler 1, 2 voor speler 2
        static int keuze; // Keuze van de speler
        static int resultaat = 0; // 1 voor winst, -1 voor gelijkspel, 0 voor doorgaan

        static void Main(string[] args)
        {
            do
            {
                pos = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                player = 1;
                resultaat = 0;

                do
                {
                    Console.Clear(); // telkens bij een nieuwe beurt het scherm wissen
                    Console.WriteLine("Speler 1: X en Speler 2: O");
                    Console.WriteLine("\n");
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Speler 2 - Beurt");
                    }
                    else
                    {
                        Console.WriteLine("Speler 1 - Beurt");
                    }
                    Console.WriteLine("\n");
                    Bord();

                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out keuze))
                    {
                        Console.WriteLine("Voer een geldig getal in!");
                        Console.ReadKey();
                        continue;
                    }

                    // Controleer of de gekozen positie leeg is
                    if (pos[keuze] != 'X' && pos[keuze] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            pos[keuze] = 'O';
                            player++;
                        }
                        else
                        {
                            pos[keuze] = 'X';
                            player++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("De rij {0} is al gevuld met een {1}", keuze, pos[keuze]);
                        Console.ReadKey();
                    }
                    resultaat = ControleerWinst();
                }
                while (resultaat != 1 && resultaat != -1);

                Console.Clear();
                Bord();

                if (resultaat == 1)
                {
                    Console.WriteLine("Speler {0} heeft gewonnen!", (player % 2) + 1);
                }
                else
                {
                    Console.WriteLine("Gelijkspel!");
                }

                Console.WriteLine("Wil je opnieuw spelen? (ja/nee)");
            }
            while (Console.ReadLine().ToLower() == "ja" || Console.ReadLine().ToLower() == "j");
        }

        // Functie om het bord te tekenen
        static void Bord()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", pos[1], pos[2], pos[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", pos[4], pos[5], pos[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", pos[7], pos[8], pos[9]);
            Console.WriteLine("     |     |      ");
        }

        // Functie om te controleren of iemand gewonnen heeft
        static int ControleerWinst()
        {
            #region Horizontaal
            if (pos[1] == pos[2] && pos[2] == pos[3])
            {
                return 1;
            }
            else if (pos[4] == pos[5] && pos[5] == pos[6])
            {
                return 1;
            }
            else if (pos[7] == pos[8] && pos[8] == pos[9])
            {
                return 1;
            }
            #endregion

            #region Verticaal
            else if (pos[1] == pos[4] && pos[4] == pos[7])
            {
                return 1;
            }
            else if (pos[2] == pos[5] && pos[5] == pos[8])
            {
                return 1;
            }
            else if (pos[3] == pos[6] && pos[6] == pos[9])
            {
                return 1;
            }
            #endregion

            #region Diagonaal
            else if (pos[1] == pos[5] && pos[5] == pos[9])
            {
                return 1;
            }
            else if (pos[3] == pos[5] && pos[5] == pos[7])
            {
                return 1;
            }
            #endregion

            #region Gelijkspel
            else if (pos[1] != '1' && pos[2] != '2' && pos[3] != '3' &&
                     pos[4] != '4' && pos[5] != '5' && pos[6] != '6' &&
                     pos[7] != '7' && pos[8] != '8' && pos[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}