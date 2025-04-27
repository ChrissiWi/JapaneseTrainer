namespace JapaneseTrainer;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnButtonAClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			button.BackgroundColor = Colors.Red;
		}
	}

	private void OnButtonBClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			button.BackgroundColor = Colors.Red;
		}
	}

	private void OnButtonCClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			button.BackgroundColor = Colors.Red;
		}
	}

	private void OnButtonDClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			button.BackgroundColor = Colors.Red;
		}
	}

	private void OnButtonNextClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			button.BackgroundColor = Colors.Green;
		}
	}

}

