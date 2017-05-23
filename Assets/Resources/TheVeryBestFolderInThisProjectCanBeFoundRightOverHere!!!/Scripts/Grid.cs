using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public int tileSize = 10;
    public const int tileNumber = 16;

    public Material water;
    public Material grass;
    public Material trees;
    public Material empty;
    /*public Texture water;
    public Texture grass;
    public Texture trees;
    public Texture empty;*/

    Renderer rend;

    int[,] generatedGrid = new int[tileNumber, tileNumber];
    GameObject[,] boardArray = new GameObject[tileNumber, tileNumber];

    //public GameObject tile;

    // Use this for initialization
    void Start()
    {
        emptyField();
    }

    public void emptyField()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < generatedGrid.GetLength(0); i++)
        {
            for (int j = 0; j < generatedGrid.GetLength(0); j++)
            {
                generatedGrid[i, j] = -1;
            }
        }

        boardArray = generateGrid(tileSize, generatedGrid, transform);
    }

    public void newGeneration()
    {
        tempRandom();
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        boardArray = generateGrid(tileSize, generatedGrid, transform);
    }

    void tempRandom()
    {
        for (int i = 0; i < generatedGrid.GetLength(0); i++)
        {
            for (int j = 0; j < generatedGrid.GetLength(0); j++)
            {
                generatedGrid[i, j] = (int)Random.Range(0, 3);
            }
        }
    }

    public GameObject[,] generateGrid(int size, int[,] genGrid, Transform parent)
    {
        GameObject[,] grid = new GameObject[tileNumber, tileNumber];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                grid[i, j].transform.position = parent.position + new Vector3(i * size, this.transform.position.y, j * size);
                //boardArray[i, j] = Instantiate(tile, new Vector3(j * tileSize, 0, i * tileSize), Quaternion.identity) as GameObject;
                grid[i, j].name = "cell" + i + j;
                grid[i, j].tag = "cell";
                grid[i, j].transform.parent = parent;
                grid[i, j].transform.localScale = new Vector3(0.1f * size, 1, 0.1f * size);

                rend = grid[i, j].GetComponent<Renderer>();

                switch (genGrid[i, j])
                {
                    case 0:
                        rend.material = water;
                        break;
                    case 1:
                        rend.material = grass;
                        break;
                    case 2:
                        rend.material = trees;
                        break;
                    default:
                        rend.material = empty;
                        break;
                }
            }
        }

        return grid;
    }
}
