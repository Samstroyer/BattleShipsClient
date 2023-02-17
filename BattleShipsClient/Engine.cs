using Raylib_cs;
using RestSharp;

public class Engine
{
    RestClient client;
    private string ipAddress;
    private readonly string port = ":3000";

    public int lobbyID;

    enum Action
    {
        Menu,
        Playing,
        Help
    }

    public Engine()
    {
        string httpStart = "http://";
        string enteredAddress = "";
        bool failed = false;

    RedoAddress:

        while (true)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawText("Current IP endpoint:\n" + httpStart + enteredAddress + "\n(this app uses port 3000)", 100, 100, 32, Color.RED);

            if (failed)
            {
                Raylib.DrawText("Error on IP: " + ipAddress, 100, 500, 32, Color.RED);
            }

            Raylib.EndDrawing();

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            if (key == KeyboardKey.KEY_ENTER) break;
            if (key == KeyboardKey.KEY_NULL) continue;
            if (key == KeyboardKey.KEY_BACKSPACE)
            {
                if (enteredAddress.Length > 0) enteredAddress = enteredAddress.Remove(enteredAddress.Length - 1);
                continue;
            }

            enteredAddress += (char)(int)key;
        }

        ipAddress = httpStart + enteredAddress + port;

        Console.WriteLine("Using: " + ipAddress);

        client = new(ipAddress);

        RestRequest tryIP = new("/TestConnection", Method.Get);
        try
        {
            RestResponse result = client.Get(tryIP);
            if (result.IsSuccessful) return;
            else
            {
                failed = true;
                goto RedoAddress;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed the call with exception: " + e);
            failed = true;
            goto RedoAddress;
        }
    }

    public void Run()
    {

    }
}
