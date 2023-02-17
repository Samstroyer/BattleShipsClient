using Raylib_cs;

public class GameCreator
{
    bool creating = true;

    public void CreateGame(ref Game game)
    {
        while (creating)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);



            Raylib.EndDrawing();

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            if (key == KeyboardKey.KEY_ESCAPE) Raylib.CloseWindow();
        }
    }
}
