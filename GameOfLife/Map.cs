using System;
using System.Threading;
namespace GameOfLife
{
    public class Map
    {

        int length;
        int height;

        public Map(int length, int height)
        {
            this.length = length;
            this.height = height;
            start();
        }

        public bool[,] mapStartup(int length, int height)
        {
            bool[,] map = new bool[length, height];

            double numberofpositions;

            numberofpositions = (length * height) * 0.51;


            for (int x = 0; x < numberofpositions; x++)
            {
                Random rnd = new Random();

                int row = rnd.Next(length);
                int col = rnd.Next(height);

                while (map[row, col])
                {
                    row = rnd.Next(length);
                    col = rnd.Next(height);
                }

                map[row, col] = true;



            }

            return map;
        }


        public void drawMap(bool[,] map)
        {
            Console.Write("+");
            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine("");

            for (int x = 0; x < map.GetLength(0); x++)
            {

                Console.Write("|");


                for (int y = 0; y < map.GetLength(1); y++)
                {

                    if (map[x, y])
                    {
                        Console.Write("X");

                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.Write("|");
                Console.WriteLine("");

            }

            Console.Write("+");
            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine("");


        }

        public void clearScreen()
        {
            System.Console.Clear();
        }




        public void start()
        {
            Logic logic = new Logic(length, height);
            bool[,] map = mapStartup(length, height);

            drawMap(map);
            while (true)
            {

                map = logic.checkRules(map);
                Thread.Sleep(1000);
                clearScreen();
                drawMap(map);

            }

        }







    }
}
