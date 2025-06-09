/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/


public class PlayerMove
{
    public bool isActive = true;
    List<int> chosenTiles = new List<int>();

    //Tagit hjälp av Chat-GPT för att generera denna kod med möjliga kombinationer (av endast par) som datorn kan göra. 
    public List<(List<List<int>>, int value)> PossibleTileCombinations = new List<(List<List<int>>, int value)>
    {
    (new List<List<int>> { new List<int> { 1 } }, 1),
    (new List<List<int>> { new List<int> { 2 } }, 2),
    (new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3 } }, 3),
    (new List<List<int>> { new List<int> { 1, 3 }, new List<int> { 4 } }, 4),
    (new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 2, 3 }, new List<int> { 5 } }, 5),
    (new List<List<int>> { new List<int> { 1, 5 }, new List<int> { 2, 4 }, new List<int> { 6 } }, 6),
    (new List<List<int>> { new List<int> { 1, 6 }, new List<int> { 2, 5 }, new List<int> { 3, 4 }, new List<int> { 7 } }, 7),
    (new List<List<int>> { new List<int> { 1, 7 }, new List<int> { 2, 6 }, new List<int> { 3, 5 }, new List<int> { 8 } }, 8),
    (new List<List<int>> { new List<int> { 1, 8 }, new List<int> { 2, 7 }, new List<int> { 3, 6 }, new List<int> { 4, 5 }, new List<int> { 9 } }, 9),
    (new List<List<int>> { new List<int> { 1, 9 }, new List<int> { 2, 8 }, new List<int> { 3, 7 }, new List<int> { 4, 6 }, new List<int> { 10 } }, 10),
    (new List<List<int>> { new List<int> { 1, 10 }, new List<int> { 2, 9 }, new List<int> { 3, 8 }, new List<int> { 4, 7 }, new List<int> { 5, 6 }, }, 11),
    (new List<List<int>> { new List<int> { 1, 11 }, new List<int> { 2, 10 }, new List<int> { 3, 9 }, new List<int> { 4, 8 }, new List<int> { 5, 7 }, }, 12)
    };


    public void ResetChosenTiles()
    {
        chosenTiles.Clear();
    }

    public void ChooseTile(int value)
    {
        if (chosenTiles.Contains(value)) RemoveChosenTiles(value);
        else AddChosenTilesToList(value);
    }

    public void CheckChosenTilesEqualsDices(List<int> diceSum, Box box)
    {
        foreach (int dice in diceSum)
        {
            if (CalculateSumofTiles() == dice)
            {
                Thread.Sleep(700);
                box.CloseTiles(chosenTiles);
                isActive = false;
            }
        }
    }

    private bool CheckIfMoveIsValid(int chosenTile) => chosenTile == 0 ? false : true;

    private void AddChosenTilesToList(int chosenTile)
    {
        if (CheckIfMoveIsValid(chosenTile))
        {
            chosenTiles.Add(chosenTile);
            PrintChosenTiles();
        }
    }

    private void RemoveChosenTiles(int chosenTile)
    {
        if (CheckIfMoveIsValid(chosenTile))
        {
            chosenTiles.Remove(chosenTile);
            PrintAfterRemove();
        }
    }

    private int CalculateSumofTiles()
    {
        int resultOfChosenTiles = 0;
        foreach (int tile in chosenTiles)
        {
            resultOfChosenTiles += tile;
        }
        return resultOfChosenTiles;
    }

    private void PrintChosenTiles()
    {
        Console.SetCursorPosition(0, 19);

        Console.Write("Chosen tiles:");

        foreach (int tile in chosenTiles)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($" {tile}");
        }
    }

    private void PrintAfterRemove()
    {
        Console.SetCursorPosition(0, 19);

        Console.Write("Chosen tiles:");

        foreach (int tile in chosenTiles)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($" {tile}");

        }
        Console.Write("   ");

    }
}


