using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour {

    public int wallRow = 8; // the position of the wall

    [Range(10, 100)]
    public float density = 10; // percent amount of the total field size at which the generation will fill

    public const int tileNumber = 16; // grid size
    private int[,] empty; // empty tiles that can be filled
    int remainingEmpty; // remaining to be filled tiles

	// Use this for initialization
	void Start ()
    {
        
	}

    // used to reset the current empty cells
    public void reset(int[,] grid)
    {
        empty = emptyCells(grid);
        addwall();
        remainingEmpty = 0;

        for (int i = 0; i < empty.GetLength(0); i++)
        {
            for (int j = 0; j < empty.GetLength(0); j++)
            {
                if (empty[i, j] == 0) remainingEmpty++;
            }
        }
    }

    // no generation zone for the wall placement
    void addwall() // Trump would be proud!
    {
        for (int i = 0; i < empty.GetLength(0); i++)
        {
            empty[i, wallRow] = 1;
        }
    }

    // this will check if the current cells in the grid array are empty
    int[,] emptyCells(int[,] grid)
    {
        int[,] amount = new int[tileNumber, tileNumber]; ;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(0); j++)
            {
                if (grid[i, j] >= 0) amount[i, j] = 1;
                else amount[i, j] = 0;
            }
        }

        return amount;
    }
	
    // fill random empty cells with a new color
	public int[,] randomGridGen (int[,] grid)
    {
        reset(grid);

        int amountToFill = (int)(((float)tileNumber * (float)tileNumber / 100) * density);

        for (int i = 0; i < amountToFill; i++)
        {
            var x = (int)Random.Range(0, 16);
            var y = (int)Random.Range(0, 16);

            if (empty[x, y] != 1)
            {
                remainingEmpty--;
                grid[x, y] = (int)Random.Range(0, 3);
                empty[x, y] = 1;
            }
            else i--;

            if (remainingEmpty == 0) i = amountToFill;
        }

        return grid;
	}
}
