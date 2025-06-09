/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

using System.Data;

public class Game
{
    Player activePlayer;
    Player player1;
    Player player2;
    bool running = true;
    Display display = new Display();

    public Game(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        player1.navigator.inputHandler.PressedSpaceBarEvent += SpacebarKeyPressed;
        player2.navigator.inputHandler.PressedSpaceBarEvent += SpacebarKeyPressed;
    }

    public Game() { }

    public void Run()
    {
        Console.CursorVisible = false;

        //InputHandler kan bytas ut till ComputerInputHandler om man vill att datorn väljer i menyerna
        IInputHandler inputHandler = new InteractiveInputHandler();
        Navigator navigator = new VerticalNavigator(inputHandler);
        Menu currentMenu = new StartMenu();
        new Display().WelcomeMessage();

        Console.WriteLine();

        while (currentMenu.menuIsActive)
        {
            Console.Clear();
            Console.WriteLine("MENU");
            Console.WriteLine();
            navigator.SetNavigatorOnList(currentMenu.MenuList);
        }
    }

    public void StartGame()
    {
        while (running)
        {
            player1.move = new PlayerMove();
            player2.move = new PlayerMove();
            activePlayer = player1;

            while (activePlayer.isActive)
            {
                bool activePlayerMakesChoice = true;

                while (activePlayerMakesChoice)
                {
                    UpdateBoard(player1, player2);

                    List<int> diceSum = DrawAndCalculateDices();

                    PrintEndRoundInfo();

                    while (activePlayer.move.isActive)
                    {
                        SetNavigatorOnActivePlayerChoices(activePlayer, diceSum);
                        activePlayer.move.CheckChosenTilesEqualsDices(diceSum, activePlayer.Box);
                    }

                    if (activePlayer.isActive)
                    {
                        activePlayer.move = new PlayerMove();
                    }

                    else
                    {
                        activePlayer = ChangeActivePlayer(player1, player2, activePlayer);
                        activePlayerMakesChoice = false;
                    }
                }
            }

            Console.ResetColor();
            CheckWinner();
            Console.ResetColor();
            EndOfGame();
        }

    }

    private void UpdateBoard(Player player1, Player player2)
    {
        Console.Clear();

        //Player 1 Name
        Console.SetCursorPosition(0, 0);
        display.DrawTextWithColor($"{player1.Name}", player1.Color.SetColor());

        //Player 1 Tiles
        Console.SetCursorPosition(0, 1);
        display.DrawPlayerChoices(player1);

        //Tärningarnas position är här
        Console.SetCursorPosition(0, 7);

        //Player 2 Name
        Console.SetCursorPosition(0, 13);
        display.DrawTextWithColor($"{player2.Name}", player2.Color.SetColor());

        //Player 2 Tiles
        Console.SetCursorPosition(0, 14);
        display.DrawPlayerChoices(player2);
    }


    private void SetNavigatorOnActivePlayerChoices(Player activePlayer, List<int> diceSum)
    {
        if (activePlayer == player1)
        {
            Console.SetCursorPosition(0, 1);
            activePlayer.navigator.SetNavigatorOnList(activePlayer.PlayerChoices, activePlayer, diceSum);
        }
        else if (activePlayer == player2)
        {
            Console.SetCursorPosition(0, 14);
            activePlayer.navigator.SetNavigatorOnList(activePlayer.PlayerChoices, activePlayer, diceSum);
        }
    }

    private List<int> DrawAndCalculateDices()
    {
        Console.SetCursorPosition(0, 7);
        char operatorDiceResult = activePlayer.operatorDice.Roll();
        int roll1;
        int roll2;

        do
        {
            roll1 = activePlayer.numberDice1.Roll();
            roll2 = activePlayer.numberDice2.Roll();
        }

        while (roll1 == roll2);

        int largestValue = roll1 < roll2 ? roll2 : roll1;
        int smallestValue = roll1 < roll2 ? roll1 : roll2;

        display.DrawDices(display.GetStringDice(largestValue), display.GetStringDice(operatorDiceResult), display.GetStringDice(smallestValue));

        DataTable table = new DataTable();
        string expression = "";
        string alternateExpression = "";
        List<int> diceResult = new List<int>();

        if (operatorDiceResult == '?')
        {
            operatorDiceResult = '-';
            alternateExpression = $"{largestValue}{'+'}{smallestValue}";
            diceResult.Add((int)table.Compute(alternateExpression, ""));
        }

        expression = $"{largestValue}{operatorDiceResult}{smallestValue}";
        diceResult.Add((int)table.Compute(expression, ""));

        Console.Write($"Result of dice roll: ");

        foreach (int diceSum in diceResult)
        {
            if (diceResult.Count>1 && diceResult.IndexOf(diceSum) == 0)
            Console.Write($"( {diceSum} ) or ");
            else Console.Write($"( {diceSum} ) ");
        }
        return diceResult;
    }

    private Player ChangeActivePlayer(Player player, Player other, Player activePlayer) => activePlayer == player ? other : player;

    private void SpacebarKeyPressed(object sender, EventArgs e)
    {
        Thread.Sleep(1500);
        activePlayer = ChangeToInactive(player1, player2, activePlayer);
        activePlayer.move.isActive = false;
    }

    private Player ChangeToInactive(Player player, Player other, Player activePlayer)
    {
        if (activePlayer == player) { player.isActive = false; return player; }
        else { other.isActive = false; return other; }
    }

    private void PrintEndRoundInfo()
    {
        Console.ResetColor();
        Console.SetCursorPosition(0, 16);
        Console.Write($"{activePlayer.Name}, press");
        display.DrawTextWithColor(" [Enter] ", ConsoleColor.DarkYellow);
        Console.Write("to confirm or remove your choice of " +
            "\r\ntile, or press");

        display.DrawTextWithColor(" [Spacebar] ", ConsoleColor.DarkYellow);
        Console.WriteLine($"if you want to end your round ");
        Console.WriteLine("                                                                  "); //rensa efter ev. multiple diceRoll
    }


    // KRAV #2:
    // 1: LINQ
    // 2: Metoden CheckWinner() använder aggregatet Sum() för att beräkna summan av öppna 'tiles' i en instans av en Box.
    // 3: LINQ används för att förenkla koden genom att undvika manuell iteration och säkerställa typsäkerhet vid beräkningen.

    private void CheckWinner()
    {
        List<(Player, int)> resultOfBoxes = new List<(Player, int)>() {
            (player1, player1.Box.Sum()),
            (player2, player2.Box.Sum())
        };

        int y = 3;
        Console.SetCursorPosition(70, 1);
        Console.WriteLine("Game result: ");
        foreach (var tuple in resultOfBoxes)
        {
            Console.SetCursorPosition(70, y);
            Console.WriteLine($"{tuple.Item1.Name} : {tuple.Item2}");
            y++;
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.SetCursorPosition(70, y);

        if (resultOfBoxes[0].Item2 == resultOfBoxes[1].Item2)
        {
            Console.WriteLine($"IT'S A TIE!");
        }
        else
        {
            var smallestValue = resultOfBoxes.MinBy(x => x.Item2);
            Console.WriteLine($"{smallestValue.Item1.Name} WINS THE GAME!");
        }
    }

    private void EndOfGame()
    {

        Console.SetCursorPosition(0, 16);
        Console.WriteLine("                                                                ");
        Console.WriteLine("Play again? Press 'Y' for Yes and 'N' for No                    ");
        var keyRestartGame = Console.ReadKey(true);

        switch (keyRestartGame.Key)
        {
            case ConsoleKey.Y:
                running = false;
                break;

            case ConsoleKey.N:

                Console.WriteLine();
                Console.WriteLine("Thank you for playing 'Shut the Box'");
                Thread.Sleep(5000);
                Environment.Exit(0);

                break;
            default:

                break;
        }
    }
}



