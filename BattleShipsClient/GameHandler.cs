using System.Timers;

public class GameHandler
{
    System.Timers.Timer updater;
    private readonly double updaterMS = 500;

    LocalPlayer lp = new();
    ForeignPlayer fp = new();

    public GameHandler()
    {
        updater = new(updaterMS)
        {
            AutoReset = true,
            Enabled = true,
        };

        updater.Elapsed += UpdateGame;
    }

    public void RunGame(ref NetworkController controller)
    {
        bool running = true;
        while (running)
        {

        }
    }

    private void UpdateGame(Object source, ElapsedEventArgs e)
    {

    }
}
