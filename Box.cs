/* 
* Objektorienterad programmering II
* Spel: "Shut The Box"
*
* Sofia Bouro Wallgren och Erika Lundström
* 2024-11-01
*/

using System.Collections;

// KRAV #1:
// 1: Iterator pattern.
// 2: Vi använder konceptet iterator pattern genom att implementera IEnumerable<int> i klassen Box. 
// 3: Vi använder konceptet för att kunna itererera över samlingen utanför klassen samt
//    för att kunna utföra olika operationer på samlingen utanför klassen (exempelvis med LINQ)
//    utan att exponera samlingens struktur.


public class Box : IEnumerable<int>
{
    private int[] tiles = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public void CloseTiles(List<int> tileList)
    {
        var iterator = GetEnumerator();

        while (iterator.MoveNext())
        {
            foreach (int tile in tileList)
            {
                if (iterator.Current == tile)
                {
                    SetValueToZero(tile);
                }
            }
        }
    }

    private void SetValueToZero(int value)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == value)
            {
                tiles[i] = 0;
            }
        }
    }

    public IEnumerator<int> GetEnumerator() => ((IEnumerable<int>)tiles).GetEnumerator();
    public int GetValueFromBox(int collectionIndex) => tiles.ElementAt(collectionIndex);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}



