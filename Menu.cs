/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public class Menu
{
    public bool menuIsActive = true;

    public List<(string, Action)> MenuList { get; set; }
    public void UpdateMenuList(List<(string, Action)> menuList) => MenuList = menuList;
 
    public bool MenuIsInactive() => menuIsActive = false;

}


