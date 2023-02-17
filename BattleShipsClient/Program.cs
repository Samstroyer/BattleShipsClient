using Raylib_cs;

Engine e;

Setup();
Draw();

void Setup()
{
    Raylib.SetTargetFPS(60);
    Raylib.InitWindow(1000, 800, "Battle Ships - Online");
    e = new();
}

void Draw()
{
    while (!Raylib.WindowShouldClose())
    {
        e.Run();
    }

    // Send to server that client exited

    Console.WriteLine("test");
}