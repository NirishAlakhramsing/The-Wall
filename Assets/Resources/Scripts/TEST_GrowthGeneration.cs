using UnityEngine;
using System.Collections;

public class TEST_GrowthGeneration : MonoBehaviour {

    //double array voor 16 bij 16 opslag

    public int tileNumber;
    public int nrOfIterations;

    [Range(0, 100)]
    public int growthChanceGrass;
    [Range(0, 100)]
    public int growthChanceTree;

    //GameObject[,] boardArray;

    private bool[] visited;
    private int[,] unvisited;
    private int[,] neighbour;

    public Grid getGridScript;

    // Use this for initialization
    void Start () {
        unvisited = new int[tileNumber, tileNumber];
        neighbour = new int[tileNumber, tileNumber];
        //boardArray = new GameObject[tileNumber, tileNumber];
        getGridScript = GameObject.Find("Grid").GetComponent<Grid>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //1 Look for all cells that have not been visited before the neigbourh gathering method activates
    public void GatherCells()
    {

        //Gather data from all grid cells
        for (int i = 0; i < getGridScript.generatedGrid.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.generatedGrid.GetLength(1); j++)
            {//COLLUM

                //Set all cells to unvisited
                unvisited[i,j] = 0;
                Debug.Log("Cell " + i+ "," + j + " has been placed in univisited array at place " + unvisited[i,j]);
                
            }
        }

        GrowSeedCell();

        //Gather the already placed seeds

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
                        Debug.Log("Found a grass cell");


                            //if not visited - start neigbour generations
                        if (unvisited[i,j] == 0)
                        {
                            Debug.Log("cell" + i+j+ " has not been visited , commence growth");

                            //GatherNeighbours(i, j);
                            //PopulateNeighbours();
                            //SetVisitation(i , j);
                        } else
                        {
                            Debug.Log("Cell" +i+j + " has already been visited and calculated , continue to next cell");
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
    }

    //3 - Generate the new neigbours with new seed cells
    public void PopulateNeighbours()
    {


        var iteration = nrOfIterations;
        var chanceGrass = growthChanceGrass;
        var chacneTree = growthChanceTree;

        // Chance randomizer for seed to grow in neighbour cell
        for (int i = 0; i < neighbour.Length; i++) {
        

        }

    }

    //4 -   Gather the current populatuble neighbours of the seed cell
    public void GatherNeighbours(int dimOne, int dimTwo)
    {
        // Info: 0 = univisted neighbour
        // Info: 1 = visited neighbour

        //right
        //neighbour[dimOne, dimTwo + 1] = 0;      // seed , + 1
        
        getGridScript.generatedGrid[dimOne, dimTwo + 1] = 1;
        //left
        neighbour[dimOne, dimTwo - 1] = 0;      // seed , - 1
        //down
        neighbour[dimOne + 1, dimTwo] = 0;      // +1 , seed 
        //up
        neighbour[dimOne - 1, dimTwo] = 0;      // -1 , seed
        //corner right down
        neighbour[dimOne + 1, dimTwo + 1] = 0;  // +1 , +1
        //corner right up
        neighbour[dimOne - 1, dimTwo + 1] = 0;  // -1 , +1
        //corner left down
        neighbour[dimOne + 1, dimTwo - 1] = 0;  // +1 , -1
        //corner left up
        neighbour[dimOne - 1, dimTwo - 1] = 0;  // -1 , -1
    }
    

    private void InitiateChance(int dimOne, int dimTwo, int type)
    {

        //Grass
        if ((int)Random.Range(0, 100) > growthChanceGrass && type == 1)
        {
            //change neighbour cell to tree cell (new seed)
            getGridScript.generatedGrid[dimOne, dimTwo] = 1;
        }

        //Tree
        if ((int)Random.Range(0, 100) > growthChanceTree && type == 2)
        {
            getGridScript.generatedGrid[dimOne, dimTwo] = 2;
        }

    }

    private void SetVisitation(int dimOne, int dimTwo)
    {
        unvisited[dimOne, dimTwo] = 1; //cell has been visited
    }
}
