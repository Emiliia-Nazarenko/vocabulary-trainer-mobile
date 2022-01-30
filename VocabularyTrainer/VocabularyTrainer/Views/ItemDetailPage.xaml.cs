using System.ComponentModel;
using VocabularyTrainer.ViewModels;
using Xamarin.Forms;

namespace VocabularyTrainer.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}