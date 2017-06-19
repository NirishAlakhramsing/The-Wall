using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
// class containing group id, number of cells, cells with correct cell positions and the cell values
public class Group // list object
{
    public string ID; // the group ID by found order
    public int amount; // amount of cells this group contains
    public int colorValue; // the color value of the cells in this group
    public int[] Xpos; // the X axis of the cells stored in this group
    public int[] Ypos; // the Y axis of cells stored in this group

    public Group(int newAmount, int newColorValue, int[,] groupToConvert, int id)
    {
        amount = newAmount;
        colorValue = newColorValue;
        ID = "number " + id;

        Xpos = new int[amount];
        Ypos = new int[amount];

        fillXYpos(groupToConvert);
    }

    private void fillXYpos(int[,] grid)
    {
        // fill the X and Y axis arrays with the correct cell position values
        int z = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(0); j++)
            {
                if (grid[i,j] == 1)
                {
                    Xpos[z] = i;
                    Ypos[z] = j;
                    z++;
                }
            }
        }
    }

}

public class CellGrouping : MonoBehaviour
{
    List<Group> cellGroup = new List<Group>(); // list containing all groups of cells larger than 1 cell in order of biggest to smallest group

    public const int tileNumber = 16; // temp grids size
    int[,] currentGroup; // all cells that have been identified as the cells in the currently identified group of cells
    int[,] currentGrid; // temporary local version of the current grid
    bool isGroup; // if theres more than 1 cell in the group, this will turn true
    bool[,] visited; // all cells that have already been accessed and processed

    public bool temp = false; // should be removed when done

    void Start () // 0
    {
        // initialize the list of groups
        reset();
    }

    void Update() // this is temporary, editor only usage
    {
        // use this method as an usage reference for other scripts
        if (temp)
        {
            temp = false; // dont use this

            createGroups(transform.GetComponent<Grid>().GetGrid()); // this should always be called before you can use the groups

            int i = 0;
            do
            { // check in a continuous loop for groups until the getnextlargestgroup returns null
                Debug.Log("amount of cells: " + getNextLargestGroup(i).amount + " in the list id: " + getNextLargestGroup(i).ID);
                // do something with the group here
                i++; // update this after the usage of the getnextlargestgroup
            } while (getNextLargestGroup(i) != null); // ends when theres no more groups remaining in the list
        }
    }

    private void reset()
    {
        // empty the list
        cellGroup.Clear();
    }

    public Group getNextLargestGroup(int number) // end, given index number for which group to get (largest to smallest)
    {
        // method for calling the current largest group of cells (the last added group to the last - the given index number)
        int listNumber = cellGroup.Count;

        if ((listNumber - 1) - number >= 0)
            return cellGroup[(listNumber - 1) - number];
        else
            return null;
    }

    public void createGroups(int[,] grid) // start, given the current array of cells
    {
        // method for detecting group formations of cells
        reset(); // empty the list
        currentGrid = grid; // fill the local version of the current grid
        visited = new bool[tileNumber, tileNumber]; // reset visited cells
        int id = 0; // used for identity in order of found groups

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (!visited[i, j] && grid[i, j] != -1)
                {
                    currentGroup = new int[tileNumber, tileNumber]; // reset curren group of cells
                    isGroup = false; // reset if its a group or not

                    findCells(i, j, grid[i,j]); // find adjecent cells
                    if (isGroup)
                    {
                        fillGroupList(grid[i, j], id); // if its a group, add it to the list as a new group
                        id++;
                    }
                }
            }
        }
    }

    bool findCells(int x, int y, int color) // 1, given the current array of cells, given the x position and y position of currently checked cell
    {
        // method for finding adjecent cells of the same color
        if (x < tileNumber && x > -1 && y < tileNumber && y > -1 && currentGrid[x, y] == color && visited[x,y] == false) // the same type of cell
        {
            currentGroup[x, y] = 1; // add cell to group
            visited[x, y] = true; // cell has been visited

            // check adjecent cells if the same and if thats true, this will be a group of cells
            if (findCells(x + 1, y, color)) isGroup = true;
            if (findCells(x - 1, y, color)) isGroup = true;
            if (findCells(x, y + 1, color)) isGroup = true;
            if (findCells(x, y - 1, color)) isGroup = true;

            return true;
        }
        else
            return false; // not the same type of cell
    }

    private void fillGroupList(int color, int id) // 2, given the group cell color
    {
        // method for filling the list of groups with the latest aditions
        // check the group size
        int cellAmount = 0;
        for (int i = 0; i < currentGroup.GetLength(0); i++)
        {
            for (int j = 0; j < currentGroup.GetLength(0); j++)
            {
                if (currentGroup[i, j] == 1) cellAmount++;
            }
        }

        // add the group of cells to a new list object
        cellGroup.Add(new Group(cellAmount, color, currentGroup, id));

        // sort the groups on size
        //sortGroups();
    }

    /*private void sortGroups() // 3
    {
        // sort all groups based on groupsize

        int i = 0;
        if (cellGroup[i] == null)
        {
            // do nothing
        }
        else
        {
            if (cellGroup[cellGroup.Count].amount > cellGroup[cellGroup.Count-i].amount)
            {
                i++;
            }
            else
            {

            }
        }
    }*/
}
