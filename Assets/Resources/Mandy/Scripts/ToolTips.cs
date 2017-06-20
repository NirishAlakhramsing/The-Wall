using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTips : MonoBehaviour {

    public Text newText;

    private int waterCount;
    private int grassCount;
    private int treeCount;
    private int cellColor = -1;

   private int waterPercentage;
   private int treePercentage;

    void Start () {

    }
    	
	void Update () {

        //TODO colorCheck isn't being called -> should be called when change is made in the grid?
        if (waterPercentage > 30)
        {
            newText.text = "There's a lot \n of water, \n make sure \n the wall is reachable";
        }

        if (treePercentage > 30)
        {
            newText.text = "There's a lot \n of trees,\n make sure \n the wall is reachable";
        }
    }

    void colorCheck()
    {
        var grid = transform.GetComponent<Grid>().GetGrid();

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                //if there is a cellColor on that position, add to the counter. 
                cellColor = grid[i, j];
                switch (cellColor)
                {
                    case 0:
                        waterCount++;
                        break;
                    case 1:
                        grassCount++;
                        break;
                    case 2:
                        treeCount++;
                        break;
                    default:
                        Debug.Log(cellColor);
                        break;
                }
            }
        }
      
        for (int i = 0; i < grid.GetLength(1); i++)
        {
            //check if anything is placed on the path towards the wall
            if (grid[7, i] != -1)
            {
                newText.text = "The path \n to the, \n wall may \n be obstructed";
            }
            else if (grid[8, i] != -1)
            {
                newText.text = "The path \n to the, \n wall may \n be obstructed";
            }
        }    
        waterPercentage = (waterCount / grid.GetLength(0)) * 100;
        treePercentage = (waterCount / grid.GetLength(0)) * 100;
    }
}


