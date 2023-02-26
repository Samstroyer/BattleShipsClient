using System.Text.Json;
using RestSharp;
using Raylib_cs;

public class NetworkController
{
    string identifier = System.Net.Dns.GetHostName(); //name
    RestClient client = new();

    public int lobbyID;
    private string ipAddress;
    private readonly string port = ":3000";

    public void ConnectClient()
    {
        string httpStart = "http://";
        string enteredAddress = "";
        bool failed = false;

    // Could probably be done without a goto, but that would require insane code indentation and more complexity. 
    // I rather just use a goto to make this work smoothly
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

            if (key == KeyboardKey.KEY_ESCAPE) Raylib.CloseWindow();

            if (key == KeyboardKey.KEY_ENTER && enteredAddress.Length > 0) break;
            if (key == KeyboardKey.KEY_NULL) continue;
            if (key == KeyboardKey.KEY_BACKSPACE)
            {
                if (enteredAddress.Length > 0) enteredAddress = enteredAddress.Remove(enteredAddress.Length - 1);
                continue;
            }

            enteredAddress += (char)(int)key;
        }

        try
        {
            // Try to connect to the IP
            ipAddress = httpStart + enteredAddress + port;
            client = new(ipAddress);
            Console.WriteLine("Using: " + ipAddress);

            // Try get the TestConnection "directory"
            RestRequest testRequest = new("/TestConnection", Method.Get);
            RestResponse result = client.Get(testRequest);

            // If it it successful, stop the loading and return back to the game
            if (result.IsSuccessful)
            {
                return;
            }

            // Else write that it failed and try again
            else
            {
                failed = true;
                goto RedoAddress;
            }
        }
        catch (Exception e)
        {
            // If exception is thrown, log it internally and try again
            Console.WriteLine("Failed the call with exception: " + e);
            failed = true;
            goto RedoAddress;
        }
    }

    public RestResponse CreateRequest(RestRequest req)
    {
        return client.Get(req);
    }

    public void CreateGame(Game game)
    {
        try
        {
            RestRequest requestVar = new($"/CreateGame/{identifier}");
            requestVar.AddBody(game);
            client.Post(requestVar);
        }
        catch (Exception e)
        {
            CustomExceptionThrower(e);
        }
    }

    public void BrowseGames(ref Game game)
    {
        try
        {
            RestRequest browse = new("/BrowseGames");
            string namesJson = client.Get(browse).Content;
            List<string> gameNames = JsonSerializer.Deserialize<List<string>>(namesJson);

            // while ()
            // {

            // }
        }
        catch (Exception e)
        {
            CustomExceptionThrower(e);
        }
    }

    private void CustomExceptionThrower(Exception e)
    {
        while (true)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawText("ERROR", 400, 10, 48, Color.RED);
            Raylib.DrawText($"Exception: \n{e}", 20, 100, 22, Color.GREEN);
            Raylib.DrawText("Press any key to go back", 230, 700, 48, Color.BLUE);

            Raylib.EndDrawing();

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            if (key != KeyboardKey.KEY_NULL) break;
        }
    }
}
