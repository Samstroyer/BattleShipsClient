using Raylib_cs;

public class GameCreator
{
    bool creating = true;
    int min = 5, max = 20;

    enum SelectedValue
    {
        Width = 0,
        Height = 1,
    }

    public void CreateGame(ref Game game)
    {
        GridTile[] displayGrid;

        int width = 10, height = 10;
        SelectedValue selected = SelectedValue.Width;

        while (creating)
        {
            displayGrid = new GridTile[width * height];

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Color c = Color.RED;

            c = selected == SelectedValue.Height ? c = Color.GREEN : c = Color.RED;
            Raylib.DrawText("Height :" + height, 100, 70, 48, c);

            c = selected == SelectedValue.Width ? c = Color.GREEN : c = Color.RED;
            Raylib.DrawText("Width :" + width, 100, 130, 48, c);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    displayGrid[x * y] = new GridTile(GridTile.State.CreatorTile);
                    displayGrid[x * y].Display(x, y, new(100, 250));
                }
            }

            Raylib.EndDrawing();

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            switch (selected)
            {
                case SelectedValue.Width:
                    if (key == KeyboardKey.KEY_RIGHT)
                    {
                        if (width < max) width++;
                    }
                    else if (key == KeyboardKey.KEY_LEFT)
                    {
                        if (width > min) width--;
                    }
                    break;

                case SelectedValue.Height:
                    if (key == KeyboardKey.KEY_RIGHT)
                    {
                        if (height < max) height++;
                    }
                    else if (key == KeyboardKey.KEY_LEFT)
                    {
                        if (height > min) height--;
                    }
                    break;
            }

            if (key == KeyboardKey.KEY_UP || key == KeyboardKey.KEY_DOWN)
            {
                switch (selected)
                {
                    case SelectedValue.Width:
                        selected = SelectedValue.Height;
                        break;
                    case SelectedValue.Height:
                        selected = SelectedValue.Width;
                        break;
                }
            }

            if (key == KeyboardKey.KEY_ESCAPE) Raylib.CloseWindow();
            if (key == KeyboardKey.KEY_ENTER) break;
        }

        game = new(width, height);
    }
}
