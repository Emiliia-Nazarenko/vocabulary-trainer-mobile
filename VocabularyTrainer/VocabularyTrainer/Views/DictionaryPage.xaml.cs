using System;
using VocabularyTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VocabularyTrainer.Data;


namespace VocabularyTrainer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DictionaryPage : ContentPage
	{
		private DictionaryViewModel vm = new DictionaryViewModel();
		public DictionaryPage()
		{
			InitializeComponent();
			BindingContext = vm = new DictionaryViewModel();


		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			vm.OnAppearing();
		}

		ViewCell lastCell;

		private void ViewCell_Tapped(object sender, EventArgs e)
		{
			if (lastCell != null)
				lastCell.View.BackgroundColor = Color.Transparent;
			var viewCell = (ViewCell)sender;
			if (viewCell.View != null)
			{
				viewCell.View.BackgroundColor = Color.Red;
				lastCell = viewCell;
			}
		}

		public void DeleteClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			var word =button.BindingContext as Word;
			var vmo = BindingContext as DictionaryViewModel;
			vmo.DeleteCommand.Execute(word);
		}
	}
}
	
