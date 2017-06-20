using UnityEngine;
using System.Collections;

public class Scramble : MonoBehaviour
{
    //TODO: make a check to see if the group isn't placed outside of the map 

    int[,] refGrid; //where the current grid gets saved
    int[,] newGrid = new int[16, 16];
    bool[,] visited = new bool[16, 16]; //all the locations that have been visisted

	// Use this for initialization
	void Start () {
        
	}

    void reset()
    {
        refGrid = transform.GetComponent<Grid>().generatedGrid; 

        for (int i = 0; i < visited.GetLength(0); i++) 
        {
            for (int j = 0; j < visited.GetLength(1); j++)
            {
                newGrid[i, j] = -1; //-1 means that it's empty
                visited[i, j] = false;
            }
        }
    }

    public void ScrambleTiles()
    {
        reset();
        transform.GetComponent<CellGrouping>().createGroups(refGrid); // this should always be called before you can use the groups

        var group = transform.GetComponent<CellGrouping>();

        int p = 0;
        if (group.getNextLargestGroup(p) != null) //only check if there are groups
        {
            do
            { // check in a continuous loop for groups until the getnextlargestgroup returns null        
                NewLocation(group.getNextLargestGroup(p)); //for each group give them a new location through getNexLargestGroup
                p++; // update this after the usage of the getnextlargestgroup
            } while (group.getNextLargestGroup(p) != null); // ends when theres no more groups remaining in the list
        }

        //Everything that is in the group is now visited, so now check all the single cells that are left.
        for (int i = 0; i < visited.GetLength(0); i++) 
        {
            for (int j = 0; j < visited.GetLength(1); j++)
            {
                //if in the reference grid it has no color, it does not need to be replaced. 
                if (refGrid[i, j] != -1)
                {
                    do
                    {
                        int xPos = Random.Range(0, 16);
                        int yPos = Random.Range(0, 16);

                        //If position is empty, give the color of repositioned cell
                        if (newGrid[xPos, yPos] == -1)
                        {
                            visited[i, j] = true;
                            newGrid[xPos, yPos] = refGrid[i, j];
                        }

                    } while (!visited[i, j]);
                }
            }
        }

        transform.GetComponent<Grid>().generatedGrid = newGrid;
    }

   public void NewLocation(Group group)
    {
        for (int i = 0; i < group.amount; i++)
        {
            int xPos = Random.Range(0, 16);
            int yPos = Random.Range(0, 16);

            if (newGrid[xPos, yPos] != -1)
            {
                visited[group.Xpos[i], group.Ypos[i]] = true;         
                newGrid[xPos, yPos] = group.colorValue;
            }
            else
            {
                i--;
            }
        } 
    }
}
