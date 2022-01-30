using VocabularyTrainer.ViewModels;
using Xamarin.Forms;


namespace VocabularyTrainer.Views
{
	public partial class LearningPage : ContentPage
	{
		public LearningPage()
		{
			InitializeComponent();
			BindingContext = new LearningViewModel();
		}
	}
}
