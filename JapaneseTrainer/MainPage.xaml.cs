using JapaneseTrainer.Data;
using JapaneseTrainer.Models;
using Microsoft.EntityFrameworkCore;

namespace JapaneseTrainer;

public partial class MainPage : ContentPage
{

	private Vocabulary _currentVocabulary;
	private List<Vocabulary> _vocabularies;

	public MainPage()
	{
		InitializeComponent();
		if (MauiProgram.DatabasePath == null)
		{
			throw new Exception("Database path is null");
		}
		else
		{
			_vocabularies = ReadVocabulariesFromDB(MauiProgram.DatabasePath);
			_currentVocabulary = _vocabularies[Random.Shared.Next(_vocabularies.Count)];
		}
	}

	private List<Vocabulary> ReadVocabulariesFromDB(string databasePath)
	{
		var options = new DbContextOptionsBuilder<JapaneseTrainerContext>()
			.UseSqlite($"Data Source={databasePath}")
			.Options;
		using var context = new JapaneseTrainerContext(options);
		return context.Vocabularies.ToList();
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

