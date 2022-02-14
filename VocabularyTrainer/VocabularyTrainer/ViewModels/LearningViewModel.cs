using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using VocabularyTrainer.Data;


namespace VocabularyTrainer.ViewModels
{
	public class LearningViewModel : BaseViewModel
	{
		int id;
		public ObservableCollection<Word> ListOfWordsBuffer;
		List<string[]> LearnedWords = new List<string[]>();
		public Command NextCardCommand { get; }
		public Command PreviousCardCommand { get; }
		public Command SwipeLeftCommand { get; }
		public Command SwipeRightCommand { get; }
		public Command BackCommand { get; }
		public bool ReversedMode { get; set; } = true;
		ICommand turnCardCommand;
		public ICommand TurnCardCommand
		{
			get { return turnCardCommand; }
		}
		string pinNo = "Start";
		public string WordOnCard
		{
			get { return pinNo; }
			set
			{
				pinNo = value;
				OnPropertyChanged();
			}
		}
		string cardCo = "#FAFA8F";
		public string CardColor
		{
			get { return cardCo; }
			set
			{
				cardCo = value;
				OnPropertyChanged();
			}
		}
		int currentWord = 0;
		public int CurrentWord
		{
			get { return currentWord; }
			set
			{
				currentWord = value;
				OnPropertyChanged();
			}
		}
		private static Random rnd = new Random();
		public static List<T> Shuffle<T>(List<T> list)
		{
			return list.OrderBy(x => rnd.Next()).ToList();
		}

		public LearningViewModel()
		{
			turnCardCommand = new Command(TurnCard);
			NextCardCommand = new Command(NextCard);
			SwipeLeftCommand = new Command(PreviousCard);
			SwipeRightCommand = new Command(NextCard);
			BackCommand = new Command(BackCommandAction);

			ListOfWordsBuffer = new ObservableCollection<Word>(App.DB.GetWordsAsync().Result);
			foreach (Word w in ListOfWordsBuffer)
			{
				LearnedWords.Add(new string[] { w.OriginalWord, w.Translation });
			}
			LearnedWords = Shuffle(LearnedWords);
			WordOnCard = LearnedWords[0][0];
		}

		void TurnCard()
		{
			id = ReversedMode ? 0 : 1;
			if (WordOnCard.Equals(LearnedWords[CurrentWord][id]))
			{
				WordOnCard = LearnedWords[CurrentWord][1 - id];
				CardColor = "#A88FFA";
			}
			else
			{
				WordOnCard = LearnedWords[CurrentWord][id];
				CardColor = "#FAFA8F";
			}
		}

		void PreviousCard()
		{
			id = ReversedMode ? 0 : 1;
			CurrentWord = Mod(--CurrentWord, LearnedWords.Count);
			WordOnCard = LearnedWords[CurrentWord][id];
			CardColor = "#FAFA8F";
		}

		void NextCard()
		{
			id = ReversedMode ? 0 : 1;
			CurrentWord = Mod(++CurrentWord, LearnedWords.Count);
			WordOnCard = LearnedWords[CurrentWord][id];
			CardColor = "#FAFA8F";
		}

		private async void BackCommandAction()
		{
			await Shell.Current.GoToAsync("..");
		}

		int Mod(int n, int d)
		{
			int result = n % d;
			if (Math.Sign(result) * Math.Sign(d) < 0)
			{
				result += d;
			}
			return result;
		}
	}
}