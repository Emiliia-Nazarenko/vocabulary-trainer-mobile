
using VocabularyTrainer.Data;
using VocabularyTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VocabularyTrainer.Views
{
	public partial class NewItemPage : ContentPage
	{
		public NewItemPage()
		{
			InitializeComponent();
			BindingContext = new NewItemViewModel();
		}
		public NewItemPage(Word word)
		{
			InitializeComponent();
			BindingContext = new NewItemViewModel(word);
		}
	}
}