using System.Numerics;
using Raylib_cs;

public class GridTile
{
    public State state;
    public int size = 30;

    public enum State
    {
        CreatorTile,
        Shown,
        ShownFull,
        Hidden,
        HiddenEmpty,
    }

    public GridTile(State gridState)
    {

    }

    public void Display(int x, int y, Vector2 topRight)
    {
        int offsetX = (int)topRight.X, offsetY = (int)topRight.Y;
        Raylib.DrawRectangleLines(offsetX + x * size, offsetY + y * size, size, size, Color.BLACK);
    }
}
