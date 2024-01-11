using HeroApp.Repository;

namespace HeroApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomePage(new HomeViewModel(new HeroeRepository()));
	}
}
