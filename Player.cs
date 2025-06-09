/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

public class Player
{
    public bool isActive = true;
    public Navigator navigator;

    // KRAV #4:
    // 1: Strategy Pattern.
    // 2: Vi använder strategy pattern då en Player har innehåller ett objekt av IColor som kan vara Red eller Blue. 
    // 3: Vi använder strategy pattern för att ge spelarna valet att påverka sitt utseende färgmässigt i realtid när ett spel skapas.

    public IColor Color;
    public Box Box;
    public string Name;
    public PlayerMove move;
    public List<(string, Action<int>)> PlayerChoices => CreatePlayerChoices();
    Display display = new Display();
    public Dice<int> numberDice1;
    public Dice<int> numberDice2;
    public Dice<char> operatorDice;
    public int CurrentCursorPosition = 0;

    public Player(Navigator navigator, IColor color, Box box, string name, Dice<int> numDice1, Dice<int> numDice2, Dice<char> opDice)
    {
        this.navigator = navigator;
        Color = color;
        Box = box;
        numberDice1 = numDice1;
        numberDice2 = numDice2;
        operatorDice = opDice;
        if (name == "" || name == " ") Name = "Unknown";
        else Name = name;
    }

    private List<(string, Action<int>)> CreatePlayerChoices()
    {
        List<(string, Action<int>)> playerChoices = new List<(string, Action<int>)>();
        string[] playerTiles = display.ConvertIntArrayBoardToStringArrayBoard(Box);
        foreach (string tile in playerTiles)
        {
            playerChoices.Add((tile, tileIndex => move.ChooseTile(Box.GetValueFromBox(tileIndex))));
        }
        return playerChoices;
    }
}
