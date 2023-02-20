using Raylib_cs;
using RestSharp;

public class Engine
{
    NetworkController networkController = new();
    GameCreator creator = new();
    Game game;

    public bool GameNotNull
    {
        get
        {
            if (game is not null) return true;
            else return false;
        }
    }

    MenuState current = MenuState.Browse;

    enum MenuState
    {
        Browse,
        Play,
        SwitchServer,
        CreateGame,
    }

    public Engine()
    {
        // networkController.ConnectClient();
        // networkController.CreateGame(game);
    }

    public void Run()
    {
        // Switch what the user wants to do
        switch (current)
        {
            case MenuState.Browse:
                Browser();
                break;
            case MenuState.CreateGame:
                creator.CreateGame(ref game);
                break;
            case MenuState.SwitchServer:
                Browser();
                break;
            case MenuState.Play:
                Browser();
                break;
        }

        // Always fall back to the browser after a method has ended
        current = MenuState.Browse;
    }

    private void Browser()
    {
        Rectangle playRec = new(350, 100, 300, 100);
        string playText = "Start Game!";

        Rectangle createRec = new(300, 200, 400, 200);
        string createText = "Create Game";

        Rectangle serverRec = new(300, 200, 400, 200);
        string serverText = "Switch Server";

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        var mousePos = Raylib.GetMousePosition();
        Raylib.DrawRectangle((int)playRec.x - 10, (int)playRec.y - 10, (int)playRec.width + 20, (int)playRec.height + 20, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mousePos, playRec)) Raylib.DrawRectangleRec(playRec, Color.GRAY);
        else Raylib.DrawRectangleRec(playRec, Color.LIGHTGRAY);
        Raylib.DrawText(playText, 390, 125, 32, Color.RED);

        // Raylib.DrawRectangleRec()
        // Raylib.DrawText()

        // Raylib.DrawRectangleRec()
        // Raylib.DrawText()

        Raylib.EndDrawing();
    }
}