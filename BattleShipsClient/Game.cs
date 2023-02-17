using System;

public class Game
{
    int[,] grid;

    LocalPlayer local = new();
    ForeignPlayer online = new();

    public Game(int gridWidth, int gridHeight)
    {
        grid = new int[gridWidth, gridHeight];
    }


}
