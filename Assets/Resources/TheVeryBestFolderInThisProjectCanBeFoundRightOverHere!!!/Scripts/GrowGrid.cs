using UnityEngine;
using System.Collections;

public class GrowGrid : MonoBehaviour {

    private int[,] visited; // cells that have not yet been touched by the growth generator
    private 

    // Use this for initialization
    void Start ()
    {
        
	}

    void empty()
    {
        for (int i = 0; i < visited.GetLength(0); i++)
        {
            for (int j = 0; j < visited.GetLength(1); j++)
            {
                visited[i, j] = 0;
            }
        }
    }

    public int[,] grow(int[,] grid)
    {
        empty();

        return grid;
    }
}
