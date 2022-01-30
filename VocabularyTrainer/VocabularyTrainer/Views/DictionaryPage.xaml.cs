using System;
using System.ComponentModel;
using VocabularyTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
	}
}
	
