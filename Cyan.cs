/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

class Cyan : IColor
{
    public string colorName { get; } = "Cyan";
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Cyan; 
    }
}