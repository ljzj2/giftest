namespace giftest;

public partial class Gif : ContentPage
{
    public Gif()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var width = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

        for (int i = 0; i < 9; i++)
        {
            var graphicsView = new GraphicsView();
            var drawable = new GifDrawable(() =>
            {
                graphicsView.Invalidate();
            });
            drawable.delay = rnd.NextDouble();
            drawable.GifPaths = Get();
            graphicsView.Drawable = drawable;

            Grid.SetRow(graphicsView, i / 3);
            Grid.SetColumn(graphicsView, i % 3);

            grid1.Children.Add(graphicsView);

            if (i % 3 == 0)
            {
                grid1.RowDefinitions.Add(new RowDefinition { Height = (width - 30) / 3 });
            }
        }

    }

    private Random rnd = new Random();
    List<Point[]> Get()
    {
        var paths = new List<Point[]>();
        for (int i = 0; i < 5; i++)
        {
            var p = new List<Point>();
            for (int j = 0; j < 15; j++)
            {
                p.Add(new Point(rnd.Next(0, 30), rnd.Next(0, 30)));
            }
            paths.Add(p.ToArray());
        }
        return paths;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        label1.Text = "this is 1";
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        label1.Text = "this is 3";
    }
}