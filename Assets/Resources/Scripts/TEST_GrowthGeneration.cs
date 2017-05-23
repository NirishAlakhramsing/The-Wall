using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    //double array voor 16 bij 16 opslag

    public int tileNumber;
    GameObject[,] boardArray;

    private bool[] visited;
    private int[] unvisited;
    private int[] neighbour;

    Grid getGridScript;

    // Use this for initialization
    void Start () {
        boardArray = new GameObject[tileNumber, tileNumber];
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GatherUnvisited()
    {
        /*for (int i = 0; i < getGridScript.generatedGrid.Length; i++)
        {
            Debug.Log("Cell " + i + " has been placed in univisited array at place " + unvisited[i]);
        }
        */

        for (int i = 0; i < getGridScript.generatedGrid.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.generatedGrid.GetLength(1); j++)
            {//COLLUM
                unvisited[i+j] = i + j;
                Debug.Log("Cell " + i + " has been placed in univisited array at place " + unvisited[i]);
            }
        }
    }

    //Look in array for the first seed ( cell from where there the growth should start )
    public void FindSeedCell()
    {
        for (int i = 0; i < getGridScript.generatedGrid.GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.generatedGrid.GetLength(1); j++)
            {//COLLUM

                switch (getGridScript.generatedGrid[i, j])
                {
                    case 0: //do nothing atm
                        break;
                    case 1: //check if visited

                            //if not - start neigbour generations
                        if ( !visited[i + j])
                        {
                            Gather(i+j);
                            NeighbourPopulating();
                        }

                        //if visited go to next cell
                        break;
                    case 2:
                        //do nothing atm
                        break;
                    default:
                        //cell has not been assigned by a object type
                        break;
                }


            }
        }
    }

    public void NeighbourPopulating()
    {
        // Chance randomizer for seed to grow in neighbour cell
        
    }

    public void Gather(int seed)
    {
        //right
        neighbour[0] = seed + 1;
        //left
        neighbour[1] = seed - 1;
        //down
        neighbour[2] = seed + 10;
        //up
        neighbour[3] = seed - 10;
        //corner right down
        neighbour[4] = (seed + 10) + 1;
        //corner right up
        neighbour[5] = (seed - 10) + 1;
        //corner left down
        neighbour[7] = (seed + 10) - 1;
        //corner left up
        neighbour[8] = (seed - 10) - 1;
    }

}
