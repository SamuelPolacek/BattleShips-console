using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleShips
{
    class Program
    {
        // Prints out Game Plan
        static void PrintGamePlan(char[,] GameField)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(GameField[j, i]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            // Game Plan 7x7
            char[,] GamePlan = { { ' ', '1', '2', '3', '4', '5', '6', '7' },
                                 { '1', '*', '*', '*', '*', '*', '*', '*' },
                                 { '2', '*', '*', '*', '*', '*', '*', '*' },
                                 { '3', '*', '*', '*', '*', '*', '*', '*' },
                                 { '4', '*', '*', '*', '*', '*', '*', '*' },
                                 { '5', '*', '*', '*', '*', '*', '*', '*' },
                                 { '6', '*', '*', '*', '*', '*', '*', '*' },
                                 { '7', '*', '*', '*', '*', '*', '*', '*' }};

            bool isWon = false;
            Regex rx = new Regex(@"^[1-7]{1} [1-7]{1}$");

            // Print out Game Field
            PrintGamePlan(GamePlan);

            // Place down BattleShips: 1x2 2x3 1x4 and 1x5
            // Arguments needed: Length, x starting, y starting, orientation (cardinal directions)
            ShipType Destroyer = new ShipType(2, 2, 1, 'e');
            ShipType Submarine = new ShipType(3, 1, 4, 'e');
            ShipType Cruiser = new ShipType(3, 7, 2, 's');
            ShipType Battleship = new ShipType(4, 5, 1, 's');
            ShipType Carrier = new ShipType(5, 3, 6, 'e');

            // Add all ships to List
            List<ShipType> Ships = new List<ShipType>
            {
                Destroyer,
                Submarine,
                Cruiser,
                Battleship,
                Carrier
            };

            // Game Loop
            while(!isWon)
            {
                // Player controller: Shooting
                bool hit = false;

                Console.WriteLine("On my mark, shoot to these coordinates!");

                // Control input - Regex
                string input = Console.ReadLine();

                while (!rx.IsMatch(input))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                }

                string[] splited = input.Split(null);
                int x = Convert.ToInt32(splited[0]);
                int y = Convert.ToInt32(splited[1]);
                int[,] xy = { { x, y } };

                Console.WriteLine();

                // Check if the coordinates contain ship and if yes then destroy
                foreach (ShipType ship in Ships)
                {
                    for (int i = 0; i < ship.Length; i++)
                    {
                        if (ship.ShipCoordinates[i, 0] == x && ship.ShipCoordinates[i, 1] == y)
                        {
                            ship.ShipCoordinates[i, 2] = 1;
                            hit = true;
                            ship.CheckShipDamage();
                        }
                    }
                }

                if (hit)
                {
                    GamePlan[x, y] = 'X';
                }
                else
                {
                    GamePlan[x, y] = 'O';
                }

                PrintGamePlan(GamePlan);
                
                // Winning condition: All ships are destroyed
                foreach (ShipType ship in Ships)
                {
                    if (!ship.isDestroyed)
                    {
                        isWon = false;
                        break;
                    }
                    else
                    {
                        isWon = true;
                    }

                }
                if (isWon)
                {
                    Console.WriteLine("All ships are destroyed, mission complete!");
                }
            }

            Console.ReadKey();
        }
    }
}

/* Ideas:
 * Player can choose from multiple Game Field sizes
 * Player can put down Battleships where he wants to
 * 2 player server
 */