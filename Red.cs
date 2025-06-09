/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


class Red : IColor
{
    public string colorName { get; } = "Red";

    public ConsoleColor SetColor()
    {
        return ConsoleColor.Red;
    }

}


