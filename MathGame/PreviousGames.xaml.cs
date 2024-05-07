using MathGame.Models;
using System;

namespace MathGame;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		gamesList.ItemsSource = App.GameRepository.GetAllGames();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.GameRepository.Delete((int)button.BindingContext);
        gamesList.ItemsSource = App.GameRepository.GetAllGames();
    }
}