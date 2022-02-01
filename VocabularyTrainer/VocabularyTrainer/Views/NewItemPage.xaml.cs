using System;
using System.Collections.Generic;
using System.ComponentModel;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;
using VocabularyTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VocabularyTrainer.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

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