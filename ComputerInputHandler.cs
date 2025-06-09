/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public class ComputerInputHandler : IInputHandler
{

    public delegate void MyEventHandler(object sender, EventArgs e);

    public event EventHandler PressedSpaceBarEvent;

    public void RaiseEvent() => PressedSpaceBarEvent?.Invoke(this, EventArgs.Empty);

    //För vertikal meny (startmeny + gametypemeny), navigerar endast random
    public int MoveCursor(List<(string, Action)> menuItems, int selectedIndex)
    {
        Random random = new Random();
        bool running = true;

        while (running)
        {
            int randomNumber = random.Next(0, 3);

            switch (randomNumber)
            {

                case 0:
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Count - 1;
                    running = false;
                    break;

                case 1: 
                    selectedIndex = (selectedIndex < menuItems.Count - 1) ? selectedIndex + 1 : 0;
                    running = false;
                    break;

                case 2: 
                    menuItems[selectedIndex].Item2();
                    running = false;
                    break;
            }
        }
        return selectedIndex;
    }


    //För horisontell meny (spelmeny)
    public void MoveCursor(List<(string, Action<int>)> menuItems, int selectedIndex, Player player, List<int> diceSum)
    {
        
        bool running = true;
        while (running)
        {
            List<int> chosenTiles = SelectPossibleSumFromBox(diceSum, player);

            if (chosenTiles.Count > 0)
            {
                foreach (int tile in chosenTiles)
                {
                    int steps = GetSteps(player, tile - 1);
                    ConsoleKey key = GetConsoleKeyDirection(player, tile);

                    for (int i = 0; i <= steps; i++)
                    {
                        if (i == steps) key = ConsoleKey.Enter;

                        Thread.Sleep(300);
                        Console.ForegroundColor = player.Color.SetColor();
                        switch (key)
                        {
                            case ConsoleKey.LeftArrow:
                                selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Count - 1;
                                player.CurrentCursorPosition = selectedIndex;
                                break;

                            case ConsoleKey.RightArrow:
                                selectedIndex = (selectedIndex < menuItems.Count - 1) ? selectedIndex + 1 : 0;
                                player.CurrentCursorPosition = selectedIndex;
                                break;

                            case ConsoleKey.Enter:
                                menuItems[selectedIndex].Item2(selectedIndex);
                                running = false;
                                break;
                        }
                    }
                }
            }

            else
            {
                RaiseEvent();
                break;
            }
        }
    }

    private ConsoleKey GetConsoleKeyDirection(Player player, int selectedIndex) => player.CurrentCursorPosition > selectedIndex ? ConsoleKey.LeftArrow : ConsoleKey.RightArrow;

    private int GetSteps(Player player, int selectedPosition) => player.CurrentCursorPosition > selectedPosition ? player.CurrentCursorPosition - selectedPosition : selectedPosition - player.CurrentCursorPosition;

    private List<int> SelectPossibleSumFromBox(List<int> diceSum, Player player)
    {
        foreach (int dice in diceSum)
        {
            player.move.ResetChosenTiles();
            foreach (var (list, value) in player.move.PossibleTileCombinations)

            {
                if (value == dice)
                {
                    foreach (var combination in list)
                    {
                        if (AreTilesOpen(combination, player))
                            return combination;
                    }
                }
            }
        }
        return new List<int>();
    }

    private bool AreTilesOpen(List<int> possibleTiles, Player player)
    {
        foreach (int tile in possibleTiles)
        {
            if (!player.Box.Contains(tile)) return false;
        }
        return true;
    }
}





