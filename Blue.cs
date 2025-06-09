/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


class Blue : IColor
{

    public string colorName { get; } = "Blue";

    public ConsoleColor SetColor()
    {
        return ConsoleColor.Blue;
    }
}
