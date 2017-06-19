using UnityEngine;
using System.Collections;

public class TEST_GrowthGeneration : MonoBehaviour {

    //double array voor 16 bij 16 opslag
    private int tileNumber;
    public int nrOfIterations;
    public float waitTime;
    private int counter = 0;

    [Range(0, 100)]
    public int waterChanceWater;
    [Range(0, 100)]
    public int growthChanceGrass;
    [Range(0, 100)]
    public int growthChanceTree;

    private int[,] visited;
    private int[,] unvisited;//INFO: 0 = not visited, 1 = visited
    private int[,] neighbour;

    public Grid getGridScript;

    private bool sWater = false;
    private bool sGrass = false;
    private bool sTree = false;
    private bool selectionOnly = false;
    public float hSliderValue = 0.0F;

    // Use this for initialization
    void Start () {

        getGridScript = GameObject.Find("Grid").GetComponent<Grid>();
        tileNumber = getGridScript.getData();

        unvisited = new int[tileNumber, tileNumber];
        neighbour = new int[tileNumber, tileNumber];
        GatherCells();

        selectionOnly = false;
    }

    //1 Gather user input data(seeds) from the grid and get all cells ready for growth proces
    public void GatherCells()
    {

        for (int i = 0; i < getGridScript.GetGrid().GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.GetGrid().GetLength(1); j++)
            {//COLLUM
                unvisited[i,j] = 0;
                neighbour[i,j] = -1;
            }
        }
    }

    //2 - Look for a seeds to grow
    public void GrowSeedCell()
    {

        for (int i = 0; i < getGridScript.GetGrid().GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.GetGrid().GetLength(1); j++)
            {//COLLUM

                switch (getGridScript.GetGrid()[i, j])
                {
                    case 0: //Water
                        if (sWater && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.generatedGrid[i, j]);
                            SetVisitation(i, j);
                        } 
                        else if (!sWater && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.GetGrid()[i, j]);
                            SetVisitation(i, j);
                        }
                        else
                        {
                            //Cell already visited
                        }
                        break;

                    case 1: //Grass
                        if (sGrass && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.generatedGrid[i, j]);
                            SetVisitation(i, j);
                        }
                        else if (!sGrass && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.GetGrid()[i, j]);
                            SetVisitation(i, j);
                        } else
                        {
                            //Cell already visited
                        }
                        break;

                    case 2://Tree

                        if (sTree && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.generatedGrid[i, j]);
                            SetVisitation(i, j);
                        }
                        else if (!sTree && unvisited[i, j] == 0)
                        {
                            GatherNeighbours(i, j, getGridScript.GetGrid()[i, j]);
                            SetVisitation(i, j);
                        }
                        else
                        {
                            //Cell already visited
                        }
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

    //3 -   Gather all neighbours that touch this cell
    public void GatherNeighbours(int dimOne, int dimTwo, int type)
    {

        var plusOne = 1;
        var minusOne = -1;
        var noAddition = 0;

        //UpperNeighbour
        if (OutOfGridCheckDim1(dimOne, noAddition) || OutOfGridCheckDim2(dimTwo, plusOne))
        {
            //This neigbour was out of the grid or already populated
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, noAddition, plusOne))
            {
                PopulateNeighbours(dimOne, dimTwo + 1, type);
            }  
        }  

        //UpperRightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, plusOne))
        {
            //This neigbour was out of the grid
        } else
        {
            if (!CellOccupation(dimOne, dimTwo, plusOne, plusOne))
            {
                PopulateNeighbours(dimOne + 1, dimTwo + 1, type);
            }
        }

        //RightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, noAddition))
        {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, plusOne, noAddition))
            {
                PopulateNeighbours(dimOne + 1, dimTwo, type);
            } 
        }

        //LowerRightNeighbour
        if (OutOfGridCheckDim1(dimOne, plusOne) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, plusOne, minusOne))
            {
                PopulateNeighbours(dimOne + 1, dimTwo - 1, type);
            }
            
        }
        
        //LowerNeighbour
        if (OutOfGridCheckDim1(dimOne, noAddition) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, noAddition, minusOne))
            {
                PopulateNeighbours(dimOne, dimTwo - 1, type);
            } 
        }

        //LowerLeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, minusOne))
        {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, minusOne, minusOne))
            {
                PopulateNeighbours(dimOne - 1, dimTwo - 1, type);
            }   
        }
        
        //LeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, noAddition)) {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, minusOne, noAddition))
            {
                PopulateNeighbours(dimOne - 1, dimTwo, type);
            }
        }

        //UpperLeftNeighbour
        if (OutOfGridCheckDim1(dimOne, minusOne) || OutOfGridCheckDim2(dimTwo, plusOne)) {
            //This neigbour was out of the grid
        }
        else
        {
            if (!CellOccupation(dimOne, dimTwo, minusOne, plusOne))
            {
                PopulateNeighbours(dimOne - 1, dimTwo + 1, type);
            }
        }

    }

    public bool OutOfGridCheckDim1(int dimOne, int dimOneaddition)
    {
        var outOfGrid = false;

        if ((dimOne + dimOneaddition) == -1)
        {
            //Cell neighbour is out of grid
            outOfGrid = true;
        } else if ( (dimOne + dimOneaddition) == tileNumber)
            {
                //Cell neighbour is out of grid;
            outOfGrid = true;
            }
        else
        {
            outOfGrid = false;
        }

        return outOfGrid;
    }

    public bool OutOfGridCheckDim2(int dimTwo, int dimTwoAddition)
    {
        var outOfGrid = false;

        if ( (dimTwo + dimTwoAddition) == -1)
        {
            //Cell neighbour is out of grid
            outOfGrid = true;
        } else if ((dimTwo + dimTwoAddition) == tileNumber)
            {
            //Cell neighbour is out of grid
            outOfGrid = true;
            }
        else
        {
            outOfGrid = false;
        }

        return outOfGrid;
    }

    public bool CellOccupation(int dimOne, int dimTwo, int additionalOne, int additionalTwo)
    {
        var occupied = false;
        if (getGridScript.GetGrid()[dimOne + additionalOne, dimTwo + additionalTwo] != -1)
        {
            occupied = true;
        } else
        {
            occupied = false;
        }
        return occupied;
    }

    //4 - Generate grass on new neigbours based on user input chances
    public void PopulateNeighbours(int dimOne, int dimTwo, int type)
    {

        // Apply the new neigbour to the UI on screen.
        if (InitiateChance(type) == type)
        {
            //gather the new neigbours so the loop can continue to check other seeds
            neighbour[dimOne, dimTwo] = type;
        }

    }

    //5 - Display the new grass on the grid
    private void ColorNewNeighbours()
    {
        for (int i = 0; i < neighbour.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < neighbour.GetLength(1); j++)
            {//COLLUM

                //Grass coloring
                if (neighbour[i,j] == 1)
                {
                    getGridScript.applyGrowthGeneration(i, j, 1);
                }

                //Water coloring
                if (neighbour[i, j] == 0)
                {
                    getGridScript.applyGrowthGeneration(i, j, 0);
                }

                //Tree coloring
                if (neighbour[i, j] == 2)
                {
                    getGridScript.applyGrowthGeneration(i, j, 2);
                }

            }
        }
    }

    private int InitiateChance(int type)
    {
        var newType = -1;

        //Water
        if ((int)Random.Range(0, 100) < waterChanceWater && type == 0)
        {
            newType = 0;
        }

        //Grass
        if ((int)Random.Range(0, 100) < growthChanceGrass && type == 1)
        {
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
