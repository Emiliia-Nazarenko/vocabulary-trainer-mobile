using System;
using System.Collections.Generic;
using VocabularyTrainer.ViewModels;
using VocabularyTrainer.Views;
using Xamarin.Forms;

namespace VocabularyTrainer
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

		}

	}
}
