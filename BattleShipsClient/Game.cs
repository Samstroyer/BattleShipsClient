using System;

public class Game
{
    GridTile[,] grid;
    public bool Creator { get; set; } = false;

    LocalPlayer local = new();
    ForeignPlayer online = new();

    public Game(int gridWidth, int gridHeight)
    {
        grid = new GridTile[gridWidth, gridHeight];
    }


}