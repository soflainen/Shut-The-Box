/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


// KRAV #5
// 1: Generics.
// 2: Vi använder generics för att kunna skapa en Dice som antingen är en vanlig tärning (int) eller en operand (char) när vi skapar en Player i PlayerFactory. 
// 3: Vi behöver generics för att kunna hantera olika typer av tärningar (char/int) på samma sätt då båda typerna av tärningar använder samma metod ('Roll()').

public class Dice<T> { 

    List<T> sides;
    Random randomDiceSide = new Random();

    public Dice(List<T> sides)
    {
        this.sides = sides;
    }

    public T Roll()
    {

        int index = randomDiceSide.Next(sides.Count);
        return sides[index];
    }

}


