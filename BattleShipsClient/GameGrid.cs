using System;

public class GameGrid
{
    bool[,] spot;

    public GameGrid(int x, int y)
    {
        spot = new bool[x, y];
    }
}
