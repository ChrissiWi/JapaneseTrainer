using JapaneseTrainer.Data;
using JapaneseTrainer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JapaneseTrainer;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	private Vocabulary? _currentVocabulary;
	private List<Vocabulary> _vocabularies;

	public Vocabulary? CurrentVocabulary
	{
		get => _currentVocabulary;
		set
		{
			_currentVocabulary = value;
			OnPropertyChanged();
		}
	}

	public string AnswerA 
	{ 
		get; 
		set; 
	} = string.Empty;

	public string AnswerB { get; set; } = string.Empty;
	public string AnswerC { get; set; } = string.Empty;
	public string AnswerD { get; set; } = string.Empty;

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
			SetAnswers();
		}
		BindingContext = this;
	}

	private void SetAnswers()
	{
		AnswerA = _vocabularies[Random.Shared.Next(_vocabularies.Count)].Translation;
		AnswerB = _vocabularies[Random.Shared.Next(_vocabularies.Count)].Translation;
		AnswerC = _vocabularies[Random.Shared.Next(_vocabularies.Count)].Translation;
		AnswerD = _vocabularies[Random.Shared.Next(_vocabularies.Count)].Translation;
		
		if (CurrentVocabulary != null)
		{
			switch (Random.Shared.Next(4))
			{
				case 0:
					AnswerA = CurrentVocabulary.Translation;
					break;
				case 1:
					AnswerB = CurrentVocabulary.Translation;
					break;
				case 2:
					AnswerC = CurrentVocabulary.Translation;
					break;
				case 3:
					AnswerD = CurrentVocabulary.Translation;
						break;
			}
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

	public new event PropertyChangedEventHandler? PropertyChanged;
	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

