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

    Renderer rend;

    private int[,] generatedGrid = new int[tileNumber, tileNumber];
    private GameObject[,] boardArray = new GameObject[tileNumber, tileNumber];

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
        generatedGrid = transform.GetComponent<GenerateGrid>().randomGridGen(generatedGrid);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        boardArray = generateGrid(tileSize, generatedGrid, transform);
    }

    public void applyGrowthGeneration(int dimOne, int dimTwo, int type)
    {

        switch (type)
        {
            case 0:
                rend = boardArray[dimOne, dimTwo].GetComponent<Renderer>();
                rend.material = water;
                generatedGrid[dimOne, dimTwo] = 0;
                break;
            case 1:
                rend = boardArray[dimOne, dimTwo].GetComponent<Renderer>();
                rend.material = grass;
                generatedGrid[dimOne, dimTwo] = 1;
                break;
            case 2:
                rend = boardArray[dimOne, dimTwo].GetComponent<Renderer>();
                rend.material = trees;
                generatedGrid[dimOne, dimTwo] = 2;
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
    }

    public int[,] GetGrid()
    {
        return generatedGrid;
    }

    public void setGrid(int[,] grid)
    {
        generatedGrid = grid;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        boardArray = generateGrid(tileSize, generatedGrid, transform);
    }

    public int getData()
    {
        return tileNumber;
    }
}
