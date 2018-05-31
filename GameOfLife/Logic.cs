using System;
namespace GameOfLife
{
    public class Logic
    {
        public int length;
        public int height;
        public Logic(int length, int height)
        {
            this.length = length;
            this.height = height;

        }


        public int countNeighbors(bool[,] welt, int x, int y)
        {
            int counter = 0;
            for (int i = x - 1; i <= x + 1; ++i)
                for (int j = y - 1; j <= y + 1; ++j)
                    if (welt[i, j])
                        counter += 1;
            if (welt[x, y]) counter -= 1;
            return counter;
        }



        public bool[,] checkRules(bool[,] map)
        {
            bool[,] newmap = new bool[length, height];
            int nachbarn;

            for (int y = 1; y < length - 1; y++)
                for (int x = 1; x < height - 1; x++)
                {
                    nachbarn = countNeighbors(map, x, y);

                    if (map[x, y])
                    {
                        if ((nachbarn < 2) || (nachbarn > 3))
                            newmap[x, y] = false;

                        if ((nachbarn == 2) || (nachbarn == 3))
                            newmap[x, y] = true;
                    }
                    else
                    {
                        if (nachbarn == 3)

                            newmap[x, y] = true;
                    }
                }
            return newmap;


        }



    }
}
