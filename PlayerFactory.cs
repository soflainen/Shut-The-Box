/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public class PlayerFactory
{
    public Player CreateHumanPlayer(IColor color, string name) =>
    new Player(
        new HorizontalNavigator(
        new InteractiveInputHandler()), 
        color, 
        new Box(), 
        name, 
        new Dice<int>(Enumerable.Range(1, 6).ToList()), 
        new Dice<int>(Enumerable.Range(1, 6).ToList()), 
        new Dice<char>(new List<char> { '+', '-', '?' }));

    public Player CreateAIPlayer(IColor color, string name) =>
        new Player(
            new HorizontalNavigator(
            new ComputerInputHandler()), 
            color, 
            new Box(), name, 
            new Dice<int>(Enumerable.Range(1, 6).ToList()), 
            new Dice<int>(Enumerable.Range(1, 6).ToList()), 
            new Dice<char>(new List<char> { '+', '-', '?'})
            );
}


