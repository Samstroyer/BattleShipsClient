using Raylib_cs;
using RestSharp;

public class Engine
{
    NetworkController networkController = new();
    GameCreator creator = new();
    Game game;

    enum Action
    {
        Menu,
        Playing,
        Help
    }

    public Engine()
    {
        networkController.ConnectClient();
        creator.CreateGame(ref game);

    }

    public void Run()
    {

    }
}
