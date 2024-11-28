namespace giftest;

public class GifDrawable : IDrawable
{
    public GifDrawable(Action? ani)
    {
        _ = Task.Run(async () =>
        {
            while (true)
            {
                Paths = GifPaths[id];

                ani?.Invoke();

                await Task.Delay(TimeSpan.FromSeconds(delay));
                id++;
                if (id >= GifPaths.Count)
                {
                    id = 0;
                }
            }
        });
    }
    public List<Point[]> GifPaths = [];
    private Point[] Paths { get; set; } = [];
    public double delay = 0.3;
    private int id = 0;
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float x = 5, y = 5, p = -1;
        var rect = new RectF();
        rect.Left = dirtyRect.Left + 1;
        rect.Top = dirtyRect.Top + 1;
        rect.Right = dirtyRect.Right - 1;
        rect.Bottom = dirtyRect.Bottom - 1;

        canvas.FillColor = Color.FromArgb("#00011c");
        canvas.FillRectangle(dirtyRect);

        var total_x = 32;
        var total_y = 32;

        if (p == -1)
        {
            p = (dirtyRect.Width - x - x) / total_x;
        }
        canvas.StrokeColor = Color.FromArgb("#aaaaaa");

        canvas.DrawRectangle(x, y, p * total_x, p * total_y);

        for (int i = 0; i < Paths.Length; i++)
        {
            var rect1 = new Rect();
            rect1.Left = x + Paths[i].X * p;
            rect1.Top = y + Paths[i].Y * p;
            rect1.Width = p;
            rect1.Height = p;

            canvas.FillColor = Color.FromArgb("#ffffff");

            canvas.FillRectangle(rect1);
        }
    }
}
