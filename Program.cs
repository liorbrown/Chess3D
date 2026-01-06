using Chess3D;

GameResult result =  GameManager.getInstance().Play();

switch (result)
{
	case GameResult.WHITE_WINS:
        Console.WriteLine("White Wins🏅");

		break;
	case GameResult.BLACK_WINS:
        Console.WriteLine("Black Wins 🏅!!!");

        break;
	case GameResult.DRAW:
        Console.WriteLine("Draw 😶");
        break;
}