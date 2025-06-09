/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

public class GameTypeMenu : Menu
{
    public GameTypeMenu()
    {

        List<(string, Action)> menuList = new List<(string, Action)>
        {
            ("Human vs Human", new Action(CreateGameHumanVsHuman)),
            ("Human vs Computer", new Action(CreateGameHumanVsAI))
        };

        UpdateMenuList(menuList);
    }

    private void CreateGameHumanVsHuman()
    {
        Console.Clear();
        Console.Write("Player 1, choose a name: ");
        string player1 = Console.ReadLine() ?? "";

        PrintChooseColor();
        IColor player1Color = SetPlayer1Color();

        Console.WriteLine("\r\n");
        Console.Write("Player 2, choose a name: ");
        string player2 = Console.ReadLine() ?? "";

        Console.WriteLine("Choose a different color from above");
        IColor player2Color = SetPlayer2Color(player1Color);

        MenuIsInactive();

        Game game = new Game(
            new PlayerFactory().CreateHumanPlayer(player1Color, player1),
            new PlayerFactory().CreateHumanPlayer(player2Color, player2)
        );
        game.StartGame();
    }

    private void CreateGameHumanVsAI()
    {
        Console.Clear();
        Console.Write("Player 1, choose a name: ");
        string player1 = Console.ReadLine() ?? "";

        PrintChooseColor();
        IColor player1Color = SetPlayer1Color();

        string player2 = "Computer";
        IColor player2Color = SetAIColor(player1Color);

        MenuIsInactive();

        Game game = new Game(
            new PlayerFactory().CreateHumanPlayer(player1Color, player1),
            new PlayerFactory().CreateAIPlayer(player2Color, player2)
        );
        game.StartGame();
    }
    public void PrintChooseColor()
    {
        Display chooseColor = new Display();
        string red = "R (red)";
        string blue = "B (blue)";
        string cyan = "C (cyan)";

        
        Console.Write("Choose a color: Press ");
        chooseColor.DrawTextWithColor(red, ConsoleColor.Red);
        Console.Write(", ");
        chooseColor.DrawTextWithColor(blue, ConsoleColor.Blue);
        Console.Write(" or ");
        chooseColor.DrawTextWithColor(cyan, ConsoleColor.Cyan);
    }

    private IColor SetPlayer1Color()
    {

        IColor player1Color = null;
        bool keyNotPressed = true;
        while (keyNotPressed)
        {
            var player1ColorKey = Console.ReadKey(true);

            switch (player1ColorKey.Key)
            {
                case ConsoleKey.R:
                    player1Color = new Red();
                    keyNotPressed = false;
                    break;
                case ConsoleKey.B:
                    player1Color = new Blue();
                    keyNotPressed = false;
                    break;
                case ConsoleKey.C:
                    player1Color = new Cyan();
                    keyNotPressed = false;
                    break;
                default:
                    break;
            }
        }
        return player1Color;
    }

    private IColor SetPlayer2Color(IColor player1Color)
    {
        IColor player2Color = null;
        bool sameColor = true;
        while (sameColor)
        {
            player2Color = SetPlayer1Color();
            if (player1Color.colorName == player2Color.colorName)
            {

                Console.WriteLine("\r\nColor is already chosen, please choose another one");
            }
            else
            {
                sameColor = false;
            }
        }

        return player2Color;
    }

    private IColor SetAIColor(IColor player1Color)
    {
        IColor aiColor = new Red();
        if (player1Color.colorName == aiColor.colorName)
        {
            aiColor = new Blue();
        }

        return aiColor;
    }
}




