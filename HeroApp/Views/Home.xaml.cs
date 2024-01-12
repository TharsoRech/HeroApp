namespace HeroApp.Views;

public partial class HomePage : ContentPage
{
    HomeViewModel homeViewModel { get; set; }
    public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel = viewModel;
	}

    void inputUser_TextChanged(object sender, TextChangedEventArgs e)
    {
        homeViewModel?.FilterName();
    }
}
