namespace MathGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Navigation.PushAsync(new GamePage(button.Text));
        }

        private void Previous_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreviousGames());
        }
    }
}
