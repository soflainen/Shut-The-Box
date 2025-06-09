/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

public class HorizontalNavigator : Navigator
{

    public HorizontalNavigator(IInputHandler inputHandler) : base(inputHandler) { }

    public override void UpdateSelectedArrowAndDrawList(List<(string, Action<int>)> menuItems, Player player)
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            if (i == SelectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"> {menuItems[i].Item1}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = player.Color.SetColor();
                Console.Write($"{menuItems[i].Item1}");
            }
        }
    }

    public override void SetNavigatorOnList(List<(string, Action<int>)> menuItems, Player player, List<int> diceSum)
    {
        UpdateSelectedArrowAndDrawList(menuItems, player);
        inputHandler.MoveCursor(menuItems, SelectedIndex, player, diceSum);
        SelectedIndex = player.CurrentCursorPosition;
    }

    public override void UpdateSelectedArrowAndDrawList(List<(string, Action)> menuItems)
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            if (i == SelectedIndex)
            {
                Console.Write($"> {menuItems[i].Item1}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{menuItems[i].Item1}");
            }
        }
    }

    public override void SetNavigatorOnList(List<(string, Action)> menuItems)
    {
        UpdateSelectedArrowAndDrawList(menuItems);
        SelectedIndex = inputHandler.MoveCursor(menuItems, SelectedIndex);
    }
}


