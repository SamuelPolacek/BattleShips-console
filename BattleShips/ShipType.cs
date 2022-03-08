using System;


namespace BattleShips
{
    public class ShipType
    {
        public int Length;
        private readonly int X, Y;
        public char Orientation;
        public int[,] ShipCoordinates;
        public bool isDestroyed = false;

        // TODO: Delete in final version
        public void PrintShipsCoordinates(int[,] Coord, int Len)
        {
            for (int i = 0; i < Len; i++)
            {
                Console.Write(Coord[i, 0]);
                Console.Write(" ");
                Console.Write(Coord[i, 1]);
                Console.WriteLine();
            }
        }

        // Check if all of the ship coordinates are destroyed and set boolean accordingly
        public void CheckShipDamage()
        {
            for(int i = 0; i < Length; i++)
            {
                if (ShipCoordinates[i,2] == 0)
                {
                    isDestroyed = false;
                    return;
                }
            }
            Console.WriteLine("Ship was destroyed!");
            Console.WriteLine();
            isDestroyed = true;
            return;
        }

        // Constructor
        public ShipType(int length, int x, int y, char orientation)
        {
            Length = length;
            X = x;
            Y = y;
            Orientation = orientation;

            /* Every part of the ship has 3 coordinates - x y d
             * 'x' and 'y' is position
             * 'd' indicates if the part was destroyed(1) or not(0)*/
            ShipCoordinates = new int[Length, 3];

            switch (Orientation)
            {
                case 'n':
                case 'N':
                    for (int i = 0; i < Length; i++)
                    {
                        ShipCoordinates[i, 0] = X;
                        ShipCoordinates[i, 1] = Y - i;
                        ShipCoordinates[i, 2] = 0;
                    }
                    break;
                case 'e':
                case 'E':
                    for (int i = 0; i < Length; i++)
                    {
                        ShipCoordinates[i, 0] = X + i;
                        ShipCoordinates[i, 1] = Y;
                        ShipCoordinates[i, 2] = 0;
                    }
                    break;
                case 's':
                case 'S':
                    for (int i = 0; i < Length; i++)
                    {
                        ShipCoordinates[i, 0] = X;
                        ShipCoordinates[i, 1] = Y + i;
                        ShipCoordinates[i, 2] = 0;
                    }
                    break;
                case 'w':
                case 'W':
                    for (int i = 0; i < Length; i++)
                    {
                        ShipCoordinates[i, 0] = X - i;
                        ShipCoordinates[i, 1] = Y;
                        ShipCoordinates[i, 2] = 0;
                    }
                    break;
            }
        }
    }
}
