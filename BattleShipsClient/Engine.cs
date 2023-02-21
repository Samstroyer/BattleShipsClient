using Raylib_cs;
using RestSharp;

public class Engine
{
    NetworkController networkController = new();
    GameCreator creator = new();
    Game game;
    GameHandler session;

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
        networkController.CreateGame(game);
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
                session = new();
                session.RunGame();
                break;
        }

        // Always fall back to the browser after a method has ended
        current = MenuState.Browse;
    }

    private void Browser()
    {
        Rectangle playRec = new(350, 100, 300, 100);
        string playText = "Start Game!";
        Rectangle createRec = new(350, 250, 300, 100);
        string createText = "Create Game";
        Rectangle serverRec = new(350, 400, 300, 100);
        string serverText = "Switch Server";

        var mousePos = Raylib.GetMousePosition();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        Raylib.DrawRectangle((int)playRec.x - 10, (int)playRec.y - 10, (int)playRec.width + 20, (int)playRec.height + 20, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mousePos, playRec)) Raylib.DrawRectangleRec(playRec, Color.GRAY);
        else Raylib.DrawRectangleRec(playRec, Color.LIGHTGRAY);
        Raylib.DrawText(playText, 390, (int)playRec.y + 25, 32, Color.RED);

        Raylib.DrawRectangle((int)createRec.x - 10, (int)createRec.y - 10, (int)createRec.width + 20, (int)createRec.height + 20, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mousePos, createRec)) Raylib.DrawRectangleRec(createRec, Color.GRAY);
        else Raylib.DrawRectangleRec(createRec, Color.LIGHTGRAY);
        Raylib.DrawText(createText, 390, (int)createRec.y + 25, 32, Color.RED);

        Raylib.DrawRectangle((int)serverRec.x - 10, (int)serverRec.y - 10, (int)serverRec.width + 20, (int)serverRec.height + 20, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mousePos, serverRec)) Raylib.DrawRectangleRec(serverRec, Color.GRAY);
        else Raylib.DrawRectangleRec(serverRec, Color.LIGHTGRAY);
        Raylib.DrawText(serverText, 390, (int)serverRec.y + 25, 32, Color.RED);

        Raylib.EndDrawing();

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, playRec) && game is not null)
            {
                networkController.CreateGame(game);
                current = MenuState.Play;
            }

            if (Raylib.CheckCollisionPointRec(mousePos, createRec))
            {

            }

            if (Raylib.CheckCollisionPointRec(mousePos, serverRec))
            {

            }

        }
    }
}