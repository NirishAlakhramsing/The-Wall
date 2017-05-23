using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    //double array voor 16 bij 16 opslag

    public int tileNumber;
    GameObject[,] boardArray;

    Grid getGridScript;


    // Use this for initialization
    void Start () {
        boardArray = new GameObject[tileNumber, tileNumber];
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Look in array for the first unvisited cell
    public void visitedCells()
    {

    }

}
