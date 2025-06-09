/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

using System.Numerics;


public abstract class Navigator
{
    // KRAV #3:
    // 1: Bridge Pattern.
    // 2: Konceptet används genom en brygga mellan den abstrakta supertypen 'Navigator' och interfacet (IInputHandler)
    //    då Navigator innehåller en implementation av IInputHandler som dess subklasser kan använda.
    // 3: Bridge Pattern används för att kunna påverka de konkreta navigatorernas beteende beroende på om hur man vill att
    //    navigeringen ska ske. På detta sätt blandar vi beteendet om hur menyn presenteras visuellt 
    //   (vertikalt eller horisontellt) med beteendet om hur input styr menyn (interaktivt eller automatiskt).  

    public IInputHandler inputHandler;

    private int selectedIndex = 0;
    public int SelectedIndex
    {
        get { return selectedIndex; }

        set
        {
            selectedIndex = value;
        }
    }  

    public Navigator(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public abstract void UpdateSelectedArrowAndDrawList(List<(string, Action)> menuItems);
    public abstract void UpdateSelectedArrowAndDrawList(List<(string, Action<int>)> menuItems, Player player);
    public abstract void SetNavigatorOnList(List<(string, Action)> menuItems);
    public abstract void SetNavigatorOnList(List<(string, Action<int>)> menuItems, Player player, List<int> diceSum);

}


