/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

public class Display
{
    public void WelcomeMessage()
    {
        Console.Write("Welcome to ");
        DrawTextWithColor("Shut the box", ConsoleColor.DarkYellow);
        Thread.Sleep(1300);
    }

    public void DrawTextWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public void DrawPlayerBox(string[] tiles, Player player)
    {
        Console.ForegroundColor = player.Color.SetColor();
        foreach (string tile in tiles)
            Console.Write(tile);
        Console.ResetColor();
    }

    public string GetStringDice(int diceSide)
    {
        //https://pub.aimind.so/creating-a-dice-rolling-simulator-in-python-2c4fe7c32ebc <- designkälla för tärningarna
        string dice = "";

        switch (diceSide)
        {
            case 1:
                dice =
               "┌─────────┐\r\n" +
               "│         │\r\n" +
               "│    ●    │\r\n" +
               "│         │\r\n" +
               "└─────────┘\r\n";
                break;

            case 2:
                dice =
                "┌─────────┐\r\n" +
                "│  ●      │\r\n" +
                "│         │\r\n" +
                "│      ●  │\r\n" +
                "└─────────┘\r\n";
                break;

            case 3:
                dice =
                "┌─────────┐\r\n" +
                "│  ●      │\r\n" +
                "│    ●    │\r\n" +
                "│      ●  │\r\n" +
                "└─────────┘\r\n";
                break;

            case 4:
                dice =
                "┌─────────┐\r\n" +
                "│  ●   ●  │\r\n" +
                "│         │\r\n" +
                "│  ●   ●  │\r\n" +
                "└─────────┘\r\n";
                break;

            case 5:
                dice =
                "┌─────────┐\r\n" +
                "│  ●   ●  │\r\n" +
                "│    ●    │\r\n" +
                "│  ●   ●  │\r\n" +
                "└─────────┘\r\n";
                break;

            case 6:
                dice =
                "┌─────────┐\r\n" +
                "│  ●   ●  │\r\n" +
                "│  ●   ●  │\r\n" +
                "│  ●   ●  │\r\n" +
                "└─────────┘\r\n";
                break;

            default:
             break;

        }

        return dice;
    }

    public string[] ConvertIntArrayBoardToStringArrayBoard(IEnumerable<int> collection)
    {
        string closedTile = "[X] ";
        string[] stringTiles = { "[1] ", "[2] ", "[3] ", "[4] ", "[5] ", "[6] ", "[7] ", "[8] ", "[9] ", "[10] " };

        foreach (var (tile, index) in collection.Select((value, i) => (value, i)))
        {
            if (tile == 0)
            {
                stringTiles[index] = closedTile;
            }
        }
        return stringTiles;
    }

    public string GetStringDice(char diceSide)
    {
        string dice = "";

        switch (diceSide)
        {
            case '+':
                dice =
                "┌─────────┐\r\n" +
                "│         │\r\n" +
                "│    +    │\r\n" +
                "│         │\r\n" +
                "└─────────┘\r\n";
                break;

            case '-':
                dice =
                "┌─────────┐\r\n" +
                "│         │\r\n" +
                "│    ─    │\r\n" +
                "│         │\r\n" +
                "└─────────┘\r\n";
                break;

            case '?':
                dice =
                "┌─────────┐\r\n" +
                "│         │\r\n" +
                "│   +/-   │\r\n" +
                "│         │\r\n" +
                "└─────────┘\r\n";
                break;

            default:
                break;

        }
        return dice;
    }

    public void DrawDices(string dice, string dice2, string dice3)
    {
        int gapWidth = 2;
        int diceWidth = dice.Split('\n')[0].Length;
        string[] diceLines = dice.Split('\n');
        string[] dice2Lines = dice2.Split('\n');
        string[] dice3Lines = dice3.Split('\n');
        int diceHeight = diceLines.Length - 1;

        int x1 = 0, y1 = 4; 
        int x2 = x1 + diceWidth + gapWidth, y2 = y1;
        int x3 = x2 + diceWidth + gapWidth, y3 = y2;

        (string[], int, int)[] intTuples = { (diceLines,x1, y1), (dice2Lines,x2, y2), (dice3Lines, x3, y3) };

        foreach (var (lines, x, y)  in intTuples)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(lines[i]);
            }
        }
        
    }

    public void DrawPlayerChoices(Player player)
    {
        Console.ForegroundColor = player.Color.SetColor();

        foreach ((string, Action<int>) choice in player.PlayerChoices)
            Console.Write(choice.Item1);
        Console.ResetColor();
    }
}


