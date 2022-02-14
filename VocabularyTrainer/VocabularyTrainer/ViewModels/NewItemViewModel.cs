using System;
using System.Collections.ObjectModel;
using VocabularyTrainer.Data;
using Xamarin.Forms;

namespace VocabularyTrainer.ViewModels
{
	public class NewItemViewModel : BaseViewModel
	{
		public ObservableCollection<Word> ListOfWordsBuffer;
		public Command SaveCommand { get; }
		private string _text;
		public string Text
		{
			get => _text;
			set => SetProperty(ref _text, value, nameof(Text));
		}
		private string _description;
		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value, nameof(Description));
		}

		public NewItemViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			this.PropertyChanged += NewItemViewModel_PropertyChanged;
		}
		
		public NewItemViewModel(Word word)
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			Text = word.OriginalWord;
			Description = word.Translation;
			this.PropertyChanged += NewItemViewModel_PropertyChanged;
		}

		private void NewItemViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(_text)
				&& !String.IsNullOrWhiteSpace(_description);
		}

		private async void OnSave()
		{
			try
			{
				var word = new Word()
				{
					OriginalWord = Text,
					Translation = Description
				};
				await App.DB.SaveWordAsync(word);
				Text = string.Empty;
				Description = string.Empty;
			}
			catch (SQLite.SQLiteException)
			{
				await Shell.Current.DisplayAlert("Notification", "This word already exists!", "ОK");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", ex.Message, "ОK");
			}
		}
	}
}
