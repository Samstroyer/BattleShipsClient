using Raylib_cs;
using RestSharp;

public class Engine
{
    RestClient client;
    private string ipAddress;
    private readonly string port = ":3000";

    public Engine()
    {
        string httpStart = "http://";
        string enteredAddress = "";

        while (true)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawText("Current IP endpoint:\n" + httpStart + enteredAddress + "\n(this app uses port 3000)", 100, 100, 32, Color.RED);

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

        Console.WriteLine(ipAddress);
    }

    public void Run()
    {

    }
}
