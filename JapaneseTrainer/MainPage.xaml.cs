using JapaneseTrainer.Data;
using JapaneseTrainer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;

namespace JapaneseTrainer;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	private Vocabulary? _currentVocabulary;
	private List<Vocabulary> _vocabularies;
	private JapaneseTrainerContext _context;
	private string? _answerA;
	private string? _answerB;
	private string? _answerC;
	private string? _answerD;
	private IAudioManager _audioManager;

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
			var options = new DbContextOptionsBuilder<JapaneseTrainerContext>()
				.UseSqlite($"Data Source={MauiProgram.DatabasePath}")
				.Options;
			_context = new JapaneseTrainerContext(options);
			_vocabularies = _context.Vocabularies.ToList();
			SelectNewWord();
		}
		BindingContext = this;
		_audioManager = AudioManager.Current;
	}

	private async Task PlayAudioAsync(string japaneseWord)
	{
		try
		{
			// Create the audio file path
			var audioFileName = $"{japaneseWord}.mp3";
			Console.WriteLine($"Attempting to play audio file: {audioFileName}");
			
			// Get the audio file from the app package
			using var stream = await FileSystem.OpenAppPackageFileAsync($"Audio/{audioFileName}");
			if (stream == null)
			{
				Console.WriteLine($"Audio file not found: {audioFileName}");
				return;
			}
			Console.WriteLine($"Successfully opened audio file: {audioFileName}");

			using var audioPlayer = _audioManager.CreatePlayer(stream);
			Console.WriteLine("Created audio player");
			
			audioPlayer.Play();
			Console.WriteLine("Started audio playback");
			
			// Wait for playback to complete
			while (audioPlayer.IsPlaying)
			{
				await Task.Delay(100);
			}
			Console.WriteLine("Audio playback completed");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error playing audio: {ex.Message}");
			Console.WriteLine($"Stack trace: {ex.StackTrace}");
		}
	}

	private void SelectNewWord()
	{
		if (!_vocabularies.Any()) return;

		// Calculate total weight based on success ratios
		var totalWeight = _vocabularies.Sum(v => 1 - v.SuccessRatio);
		var random = new Random();
		var randomValue = random.NextDouble() * totalWeight;

		// Select word based on weights
		double currentWeight = 0;
		foreach (var word in _vocabularies)
		{
			currentWeight += 1 - word.SuccessRatio;
			if (randomValue <= currentWeight)
			{
				CurrentVocabulary = word;
				SetAnswers();
				break;
			}
		}
	}

	private void SetAnswers()
	{
		if (CurrentVocabulary == null) return;

		// Get 3 random translations from other words
		var otherTranslations = _vocabularies
			.Where(v => v.Id != CurrentVocabulary.Id)
			.OrderBy(x => Random.Shared.Next())
			.Take(3)
			.Select(v => v.Translation)
			.ToList();

		// Add the correct answer
		var allAnswers = new List<string> { CurrentVocabulary.Translation };
		allAnswers.AddRange(otherTranslations);

		// Shuffle the answers
		allAnswers = allAnswers.OrderBy(x => Random.Shared.Next()).ToList();

		// Assign to buttons
		AnswerA = allAnswers[0];
		AnswerB = allAnswers[1];
		AnswerC = allAnswers[2];
		AnswerD = allAnswers[3];
	}

	private async void OnAnswerButtonClicked(object sender, EventArgs e)
	{
		if (CurrentVocabulary == null) return;

		Button? button = sender as Button;
		if (button != null)
		{
			bool isCorrect = button.Text == CurrentVocabulary.Translation;
			
			// Update answer counts
			if (isCorrect)
			{
				CurrentVocabulary.NumberRightAnswers++;
				button.BackgroundColor = Colors.LightGreen;
				// Play the audio for the correct answer
				await PlayAudioAsync(CurrentVocabulary.JapaneseWord);
			}
			else
			{
				CurrentVocabulary.NumberWrongAnswers++;
				button.BackgroundColor = Colors.LightCoral;
			}

			// Save changes to database
			_context.SaveChanges();
		}
	}

	private void OnButtonNextClicked(object sender, EventArgs e)
	{
		Button? button = sender as Button;
		if (button != null)
		{
			// Reset background colors
			AnswerButtonA.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonB.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonC.BackgroundColor = Colors.LightSkyBlue;
			AnswerButtonD.BackgroundColor = Colors.LightSkyBlue;

			// Select new word
			SelectNewWord();
		}
	}

	public new event PropertyChangedEventHandler? PropertyChanged;
	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

