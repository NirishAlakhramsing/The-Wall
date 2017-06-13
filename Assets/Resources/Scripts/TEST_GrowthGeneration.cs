using UnityEngine;
using System.Collections;

public class TEST_GrowthGeneration : MonoBehaviour {

    //double array voor 16 bij 16 opslag
    private int tileNumber;
    public int nrOfIterations;
    public float waitTime;
    private int counter = 0;

    [Range(0, 100)]
    public int growthChanceGrass;
    [Range(0, 100)]
    public int growthChanceTree;

    //GameObject[,] boardArray;
    
    private int[,] visited;
    public int[,] unvisited;
    private int[,] neighbour;

    public Grid getGridScript;

    // Use this for initialization
    void Start () {

        getGridScript = GameObject.Find("Grid").GetComponent<Grid>();
        tileNumber = getGridScript.getData();

        unvisited = new int[tileNumber, tileNumber];
        neighbour = new int[tileNumber, tileNumber];
        GatherCells();

    }
	

    //1 Look for all cells that have not been visited before the neigbourh gathering method activates
    public void GatherCells()
    {
        // 0. Gather data from all grid cells
        for (int i = 0; i < getGridScript.generatedGrid.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.generatedGrid.GetLength(1); j++)
            {//COLLUM

                //Set all cells to unvisited
                unvisited[i,j] = 0;
                neighbour[i,j] = 0;
                //Debug.Log("Cell " + i+ "," + j + " has been placed in univisited array at place " + unvisited[i,j]); //HEAVY ON PERFORMANCE

            }
        }
    }

    //2 - Look in array for a seeds to grow
    public void GrowSeedCell()
    {

        for (int i = 0; i < getGridScript.generatedGrid.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.generatedGrid.GetLength(1); j++)
            {//COLLUM

                switch (getGridScript.generatedGrid[i, j])
                {
                    case 0: //Water - do nothing atm
                        break;

                    case 1: //Grass - check if visited

                        //if not visited - start neigbour generations
                        if (unvisited[i, j] == 0)
                        {
                            //Debug.Log("cell" + i + "," + j + " has not been visited , commence growth");

                            GatherNeighbours(i, j, 1);
                            //PopulateNeighbours();
                            SetVisitation(i, j);
                        } else
                        {
                            //Debug.Log("Cell" +i+ "," +j + " has already been visited and calculated , continue to next cell");
                        }
                        break;

                    case 2://Tree - do nothing atm

                        break;
                    default:
                        //cell has not been assigned by a object type
                        break;
                }
            }
        }

        //after a iteration of neigbours populating color the new neighbour cells
        ColorNewNeighbours();

        StartCoroutine(GrowthIterator());
    }

    //3 -   Gather the current populatuble neighbours of the seed cell
    public void GatherNeighbours(int dimOne, int dimTwo, int type)
    {

        var plusOne = 1;
        var minusOne = -1;
        var noAddition = 0;

        //UpperNeighbour
        if (OutOfGridCheckDim1(dimOne, noAddition) || OutOfGridCheckDim2(dimTwo, plusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne, dimTwo + 1, type);
        }
        

        //UpperRightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, plusOne))
        {
            //This neigbour was out of the grid
        } else
        {
            PopulateNeighbours(dimOne + 1, dimTwo + 1, type);
        }
        

        //RightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, noAddition))
        {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne + 1, dimTwo, type);
        }

        //LowerRightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne + 1, dimTwo - 1, type);
        }
        
        //LowerNeighbour
        //PopulateNeighbours(dimOne, dimTwo - 1, type);
        if (OutOfGridCheckDim1(dimOne, noAddition) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne, dimTwo - 1, type);
        }

        //LowerLeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne - 1, dimTwo - 1, type);
        }
        
        //LeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, noAddition)) {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne - 1, dimTwo, type);
        }

        //UpperLeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, plusOne)) {
            //This neigbour was out of the grid
        }
        else
        {
            PopulateNeighbours(dimOne - 1, dimTwo + 1, type);
        }


        //Set original seed to visited
        //SetVisitation(dimOne, dimTwo);

        //cell is already filled with a object
        //Debug.Log("Cell is already filled with object of type " + getGridScript.generatedGrid[dimOne, dimTwo + 1]);

    }

    public bool OutOfGridCheckDim1(int dimOne, int dimOneaddition)
    {
        var outOfGrid = false;

        if ((dimOne + dimOneaddition) == -1)
        {
            //grid value is out of grid
            //Do not populate
            //Go to next neighbour
            //Debug.Log("Negative cell " + (dimOne + dimOneaddition));
            outOfGrid = true;
        } else if ( (dimOne + dimOneaddition) == tileNumber)
            {
                //Debug.Log("Over cell maximum " + (dimOne + dimOneaddition));
            outOfGrid = true;
            }
        else
        {
            //Debug.Log("This neighbour is INSIDE of grid Dimension One " + (dimOne + dimOneaddition));
            outOfGrid = false;
        }

        return outOfGrid;
    }

    public bool OutOfGridCheckDim2(int dimTwo, int dimTwoAddition)
    {
        var outOfGrid = false;

        if ( (dimTwo + dimTwoAddition) == -1)
        {
            //grid value is out of grid
            //Do not populate
            //Go to next neighbour
            //Debug.Log("This neighbour is out of grid Dimension Two " + (dimTwo + dimTwoAddition));
            //Debug.Log("Negative cell " + (dimTwo + dimTwoAddition));
            outOfGrid = true;
        } else if ((dimTwo + dimTwoAddition) == tileNumber)
            {
                //Debug.Log("Over cell maximum " + (dimTwo + dimTwoAddition));
                outOfGrid = true;
            }
        else
        {
            outOfGrid = false;
        }

        return outOfGrid;
    }


    //4 - Generate the new neigbours with new seed cells
    public void PopulateNeighbours(int dimOne, int dimTwo, int type)
    {

        // Apply the new neigbour to the UI on screen.
        if (InitiateChance(type) == type)
        {
            //gather the new neigbours so the loop can continue to check other seeds
            neighbour[dimOne, dimTwo] = type;
        }

        //getGridScript.applyGrowthGeneration(dimOne, dimTwo, InitiateChance(type));

        //add to new neigbours for further iterations and visitation settings.
        //neighbour[dimOne, dimTwo] = 1;
    }

    private void ColorNewNeighbours()
    {
        for (int i = 0; i < neighbour.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < neighbour.GetLength(1); j++)
            {//COLLUM

                //grass coloring
                if (neighbour[i,j] == 1)
                {
                    getGridScript.applyGrowthGeneration(i, j, 1);
                }

            }
        }
    }

    private int InitiateChance(int type)
    {
        var newType = 0;
        //Grass
        if ((int)Random.Range(0, 100) < growthChanceGrass && type == 1)
        {
            //change neighbour cell to tree cell (new seed)
            newType = 1;
        }

        //Tree
        if ((int)Random.Range(0, 100) < growthChanceTree && type == 2)
        {
            newType = 2;
        }

        return newType;
    }

    private void SetVisitation(int dimOne, int dimTwo)
    {
        unvisited[dimOne, dimTwo] = 1; //cell has been visited
    }

    private IEnumerator GrowthIterator()
    {
        

        if (counter != (nrOfIterations -1))
        { 
        yield return new WaitForSeconds(waitTime);
            counter++;
            GrowSeedCell();
            
        } else
        {
            counter = 0;
        }
    }
}
