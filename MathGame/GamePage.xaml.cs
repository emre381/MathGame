using MathGame.Models;

namespace MathGame;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }
	int firstNumber = 0;
	int secondNumber = 0;
	int score = 0;
	const int totalQuestions = 2;
	int gamesLeft = totalQuestions;
	public GamePage(string gameType)
	{
		InitializeComponent();
		GameType = gameType;
		BindingContext = this;
		CreateNewQuestions();
	}
	private void CreateNewQuestions()
	{
		var gameOperand = GameType switch
		{
			"Addition" => "+",
            "Subtraction" => "-",
            "Multiplication" => "*",
            "Division" => "/",
			_ =>""


        };
		var random = new Random();
	
		firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);

		 
		secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99); 
		if(GameType == "Division")
		{
			while(firstNumber < secondNumber || firstNumber % secondNumber !=0 )

			{
				firstNumber=random.Next(1, 99);
				secondNumber = random.Next(1, 99);
			}
		}
		QuestionLabel.Text = $"{firstNumber}{gameOperand}{ secondNumber}";
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(AnswerEntry.Text))
        {
            // Giriş null veya boşsa, kullanıcıya bir mesaj göster
            AnswerLabel.Text = "Please enter your Answer";
            return; // Metodu burada sonlandır, işlem devam etmesin
        }
        var answer = int.Parse(AnswerEntry.Text);
		var isCorrect = false;
		 switch (GameType)
		{
			case "Addition":
				isCorrect = answer == firstNumber + secondNumber;
				break;
            case "Subtraction":
                isCorrect = answer == firstNumber - secondNumber;
                break;
            case "Multiplication":
                isCorrect = answer == firstNumber * secondNumber;
                break;
            case "Division":
                isCorrect = answer == firstNumber / secondNumber;
                break;
        }
        ProcessAnswer(isCorrect);
		gamesLeft--;
		AnswerEntry.Text = "";
		if (gamesLeft > 0)
			CreateNewQuestions();
		else
			GameOver();

    }

    private void GameOver()
    {
        GameOperataion gameOperataion = GameType switch
        {
            "Addition" => GameOperataion.Addition,
            "Subtraction" => GameOperataion.Subtraction,
            "Multiplication" => GameOperataion.Multiplication,
            "Division" => GameOperataion.Division,
            "+" => GameOperataion.Addition, // Handle "+" as well
            "-" => GameOperataion.Subtraction, // Handle "-" as well
            "*" => GameOperataion.Multiplication, // Handle "*" as well
            "/" => GameOperataion.Division, // Handle "/" as well
            _ => throw new ArgumentException("Invalid game type"), // Handle any other unexpected value
        };

        QuestionArea.IsVisible = false;
		BackToMenuBtn.IsVisible = true;
		GameOverLabel.Text = $"Game Over! Your got {score} out of {totalQuestions} right  ";
		App.GameRepository.Add(new Game
		{
			DatePlayed = DateTime.Now,
			Type = gameOperataion,
			Score = score,
		});
    }

    private void ProcessAnswer(bool isCorrect)
    {
        if (isCorrect)
		{
			score +=1 ;

			AnswerLabel.Text = isCorrect ? "Correct" : "Incorrect";

		}
    }

    private void BackToMenuBtn_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainPage());
    }
}