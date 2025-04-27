using JapaneseTrainer.Data;
using JapaneseTrainer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JapaneseTrainer;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	private Vocabulary _currentVocabulary;
	private List<Vocabulary> _vocabularies;

	public Vocabulary CurrentVocabulary
	{
		get => _currentVocabulary;
		set
		{
			_currentVocabulary = value;
			OnPropertyChanged();
		}
	}

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
			CurrentVocabulary = _vocabularies[Random.Shared.Next(_vocabularies.Count)];
		}
		BindingContext = this;
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

	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

