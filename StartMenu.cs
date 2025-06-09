/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

public class StartMenu : Menu
{
    public StartMenu()
    {
        List<(string, Action)> menuList = new List<(string, Action)>
        {
            ("Type of game", new Action(CreateGameTypeMenu)),
            ("How to play", new Action(HowToPlay))

    };
        UpdateMenuList(menuList);
    }

    private void CreateGameTypeMenu()
    {
        GameTypeMenu newMenu = new GameTypeMenu();
        UpdateMenuList(newMenu.MenuList);
    }


    private void HowToPlay()
    {
        Display display = new Display();

        Console.WriteLine("\r\n In Shut The Box you need to close as many numbers as " +
                          "\r\n possible and become the player with the lowest score." +
                          "\r\n In this version, you have three dice: two normal dice" +
                          "\r\n and one operator die (+, -, +/-)." +
                          "\r\n " +
                          "\r\n You must close one or more tiles equal to the sum or" +
                          "\r\n difference of these dice depending on the operator.\r\n");

        display.DrawTextWithColor("Example 1:", ConsoleColor.Green);
        Console.WriteLine(" If the two number dice show 4 and 5 and the operator " +
                          "\r\n die shows '+' then you can close any tiles equal to 9.\r\n");

        display.DrawTextWithColor("Example 2:", ConsoleColor.Green);
        Console.WriteLine(" If the two number dice show 2 and 6 and the operator  " +
                          "\r\n die shows '-', then you can close any tiles equal to 4.\r\n");

        display.DrawTextWithColor("Example 3:", ConsoleColor.Green);
        Console.WriteLine(" If the two number dice show 3 and 2 and the operator " +
                          "\r\n die shows '+/-', then you can either choose any tiles " +
                          "\r\n equal to 5 (3 + 2) or any tiles equal to 1 (3 - 2)\r\n");

        Console.WriteLine(" The game ends when both players have " +
                        "\r\n finished closing all possible tiles.");

        display.DrawTextWithColor("\r\n NOTE: ", ConsoleColor.Red);
        Console.WriteLine("If you want to use tile 1 and 4 to get the sum of 5 " +
            "\r\n in example 3, you need to choose tile 1 last.");

        display.DrawTextWithColor("\r\nPress any key to go back", ConsoleColor.Green);

        Console.ReadKey(true);
        Console.Clear();
        UpdateMenuList(MenuList);
    }
}



