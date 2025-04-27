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
    private string? _answerA;
    private string? _answerB;
    private string? _answerC;
    private string? _answerD;

    public Vocabulary? CurrentVocabulary
	{
		get => _currentVocabulary;
		set
		{
			_currentVocabulary = value;
			OnPropertyChanged();
		}
	}

	public string? AnswerA 
	{ 
		get => _answerA;
		set
		{
			_answerA = value;
			OnPropertyChanged();
		}
	}

	public string? AnswerB 
	{ 
		get => _answerB;
		set
		{
			_answerB = value;
			OnPropertyChanged();
		}
	}

	public string? AnswerC 
	{ 
		get => _answerC;
		set
		{
			_answerC = value;
			OnPropertyChanged();
		}
	}

	public string? AnswerD 
	{ 
		get => _answerD;
		set
		{
			_answerD = value;
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

	private void OnAnswerButtonClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			if (button.Text == CurrentVocabulary?.Translation)
			{
				button.BackgroundColor = Colors.LightGreen;
			}
			else
			{
				button.BackgroundColor = Colors.LightCoral;
			}
		}
	}


	private void OnButtonNextClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			CurrentVocabulary = _vocabularies[Random.Shared.Next(_vocabularies.Count)];
			SetAnswers();
			
			// Reset background colors
			AnswerButtonA.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonB.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonC.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonD.BackgroundColor = Colors.LightSkyBlue;
		}
	}

	public new event PropertyChangedEventHandler? PropertyChanged;
	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

