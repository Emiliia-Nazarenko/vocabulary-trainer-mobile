using System;
using VocabularyTrainer.Services;
using VocabularyTrainer.Views;
using Xamarin.Forms;
using VocabularyTrainer.Data;
using System.IO;

namespace VocabularyTrainer
{
	public partial class App : Application
	{
		public static Database DB;

		public App()
		{
			InitializeComponent();
			DependencyService.Register<MockDataStore>();
			Xamarin.Forms.DataGrid.DataGridComponent.Init();
			var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase_v2.db3");
			DB = new Database(dbPath);
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
