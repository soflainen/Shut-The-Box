/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public class InteractiveInputHandler : IInputHandler
{
    public delegate void MyEventHandler(object sender, EventArgs e);

    public event EventHandler PressedSpaceBarEvent;

    public void RaiseEvent() => PressedSpaceBarEvent?.Invoke(this, EventArgs.Empty);


    //För vertikal meny (startmeny + gametypemeny)
    public int MoveCursor(List<(string, Action)> menuItems, int selectedIndex)
    {
        bool running = true;

        while (running)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow)
            {
                key = ConsoleKey.RightArrow;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                key = ConsoleKey.LeftArrow;
            }

            switch (key)
            {

                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Count - 1;
                    running = false;
                    break;

                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex < menuItems.Count - 1) ? selectedIndex + 1 : 0;
                    running = false;
                    break;

                case ConsoleKey.Enter:
                    menuItems[selectedIndex].Item2();
                    running = false;
                    break;
            }
        }
        return selectedIndex;
    }


    public void MoveCursor(List<(string, Action<int>)> menuItems, int selectedIndex, Player player, List<int> diceSum)
    {
        bool running = true;

        while (running)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow)
            {
                key = ConsoleKey.RightArrow;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                key = ConsoleKey.LeftArrow;
            }

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuItems.Count - 1;
                    player.CurrentCursorPosition = selectedIndex;
                    running = false;
                    break;

                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex < menuItems.Count - 1) ? selectedIndex + 1 : 0;
                    player.CurrentCursorPosition = selectedIndex;
                    running = false;
                    break;

                case ConsoleKey.Enter:
                    menuItems[selectedIndex].Item2(selectedIndex);
                    running = false;
                    break;

                case ConsoleKey.Spacebar:
                    RaiseEvent();
                    running = false;
                    break;

            }
        }
    }
}
