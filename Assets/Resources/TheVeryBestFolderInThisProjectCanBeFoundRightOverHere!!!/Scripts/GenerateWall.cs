using UnityEngine;
using System.Collections;

public class GenerateWall : MonoBehaviour
{
    private int wallRow = 8; // the position of the wall
    private int[,] wall;
    
    void generateWall ()
    {
        wall = new int[16, 16];

        for (int i = 0; i < wall.GetLength(0); i++)
        {
            wall[i, wallRow] = 1;
        }
    }
	
	public int[,] getWall ()
    {
        generateWall();
        return wall;
	}

    public void setWall (int wallRowToSet)
    {
        wallRow = wallRowToSet;
    }
}
