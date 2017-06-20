using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour
{
    [Range(10, 100)]
    public float density = 10; // percent amount of the total field size at which the generation will fill

    public const int tileNumber = 16; // grid size
    private int[,] empty; // empty tiles that can be filled
    int remainingEmpty; // remaining to be filled tiles

    DNA dna; // the dna that will be used to identify the chance of what type of generations will appear

    // Use this for initialization
    void Start ()
    {
        dna = new DNA();
	}

    public void newGeneration()
    {
        transform.GetComponent<Grid>().setGrid(randomGridGen(transform.GetComponent<Grid>().GetGrid()));
    }

    // used to reset the current empty cells
    void reset(int[,] grid)
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
            for (int j = 0; j < empty.GetLength(0); j++)
            {
                if (transform.GetComponent<GenerateWall>().getWall()[i, j] == 1)
                    empty[i, j] = 1;
            }
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
	int[,] randomGridGen (int[,] grid)
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
                var rand = (int)Random.Range(1, 3);

                int[] check = checkNeighbours(x, y, grid);
                if (rand <= check[0] && check[1] > -1)
                    grid[x, y] = check[1];
                else
                    grid[x, y] = dna.getDNASample(x, y);

                /*
                instead of using a random integer, there will be a dna based system that defines the chances of a specific type of cell to spawn.
                besides that, the cells next to existing cells will need to have a higher chance of being the same type as its neighbour.
                also in consecutive generations, the system should more likely spawn cells next to existing ones rather than on random locations.
                */

                empty[x, y] = 1;
            }
            else i--;

            if (remainingEmpty == 0) i = amountToFill;
        }

        return grid;
	}

    int[] checkNeighbours(int x, int y, int[,] grid)
    {
        // method for finding adjecent cells of the same color
        int number = 0;
        int color = 0;

        int[] type = new int[3];

        if (x - 1 < tileNumber && x - 1 > -1 && y < tileNumber && y > -1)
            if (grid[x - 1, y] > -1 && grid[x - 1, y] < 3)
                type[grid[x - 1, y]]++;

        if (x + 1 < tileNumber && x + 1 > -1 && y < tileNumber && y > -1)
            if (grid[x + 1, y] > -1 && grid[x + 1, y] < 3)
                type[grid[x + 1, y]]++;

        if (x < tileNumber && x > -1 && y - 1 < tileNumber && y - 1 > -1)
            if (grid[x, y - 1] > -1 && grid[x, y - 1] < 3)
                type[grid[x, y - 1]]++;

        if (x < tileNumber && x > -1 && y + 1 < tileNumber && y + 1 > -1)
            if (grid[x, y + 1] > -1 && grid[x, y + 1] < 3)
                type[grid[x, y + 1]]++;

        for (int i = 0; i < type.Length; i++)
        {
            if (type[i] > number)
            {
                number = type[i];
                color = i;
            }
        }

        return new int[2] { number, color };
    }
}
