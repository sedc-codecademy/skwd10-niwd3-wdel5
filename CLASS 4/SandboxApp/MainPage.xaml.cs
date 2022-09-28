namespace SandboxApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	Button CounterBtn;


    public MainPage()
	{
		InitializeComponent();

		//SecondLabel.Text = "Changed from constructor";

		var image = new Image
		{
			Source = "dotnet_bot.png",
			HeightRequest = 100,
			HorizontalOptions = LayoutOptions.Center
		};

		var label = new Label
		{
			Text = "Hello, World!",
			FontSize = 32,
			HorizontalOptions = LayoutOptions.Center
		};

		var label1 = new Label
		{
			Text = "Welcome to .NET Multi-platform App UI",
			FontSize = 18,
			HorizontalOptions = LayoutOptions.Center
		};

		CounterBtn = new Button
		{
			Text = "Click Me!",
			HorizontalOptions = LayoutOptions.Center
		};
		CounterBtn.Clicked += OnCounterClicked;

		Content = new ScrollView
		{
			Content = new VerticalStackLayout
			{
				Children =
				{
					image,
					label,
					label1,
					CounterBtn
				},
				VerticalOptions = LayoutOptions.Center,
				Spacing = 35,
				Padding = new Thickness(30, 0),
			},
		};
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		//SecondLabel.Text = $"Changed from button click {count}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

