/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public interface IInputHandler
{
    public int MoveCursor(List<(string, Action)> menuItems, int selectedIndex);
    public void MoveCursor(List<(string, Action<int>)> menuItems, int selectedIndex, Player player, List<int> diceSum);

    event EventHandler PressedSpaceBarEvent;
    void RaiseEvent();
}


