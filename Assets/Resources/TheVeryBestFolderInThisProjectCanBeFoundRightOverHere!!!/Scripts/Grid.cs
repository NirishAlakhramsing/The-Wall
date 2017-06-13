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

    public int[,] generatedGrid = new int[tileNumber, tileNumber];
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
            Destroy(child.gameObject);
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

    public void applyGrowthGeneration(int dimOne, int dimTwo, int type)
    {
        //boardArray = generateGrid(tileSize, generatedGrid, transform);
        //Debug.Log("Cell = " + dimOne +","+dimTwo +" are new");

        switch (type)
        {
            case 0:
                //rend.material = water;
                break;
            case 1:
                rend = boardArray[dimOne, dimTwo].GetComponent<Renderer>();
                rend.material = grass;
                generatedGrid[dimOne, dimTwo] = 1;
                break;
            case 2:
                //rend.material = trees;
                break;
            default:
                //rend.material = empty;
                break;
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
                grid[i, j].name = "cell" + i.ToString("00") + j.ToString("00");
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

    public void setCellColor(string name, int color)
    {
        int numberX = 0;
        int.TryParse(name.Substring(4, 2), out numberX);

        int numberY = 0;
        int.TryParse(name.Substring(name.Length - 2), out numberY);

        generatedGrid[numberX, numberY] = color;

        //Debug.Log(generatedGrid[numberX, numberY]);
    }

    /*public int[,] GetGeneratedGrid()
    {
        int[,] grid = new int[tileNumber, tileNumber];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(0); j++)
            {
                
            }
        }

        return grid;
    }*/

    /*void Update()
    {
        var cell = "cell1022";
        int number = 0;

        int.TryParse(cell.Substring(4, 2), out number);
        Debug.Log(number);
        Debug.Log(cell.Substring(cell.Length-2));
        //Debug.Log(boardArray[0, 0].transform.GetComponent<Renderer>().material);
    }*/

    public int getData()
    {
        return tileNumber;
    }
}
