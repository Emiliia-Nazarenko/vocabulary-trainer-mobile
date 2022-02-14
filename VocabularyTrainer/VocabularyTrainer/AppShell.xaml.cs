using VocabularyTrainer.Views;
using Xamarin.Forms;

namespace VocabularyTrainer
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
		}
	}
}
