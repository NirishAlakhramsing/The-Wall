using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public float tileSize = 10;

    public const int tileNumber = 16;
    Renderer rend;

    int[] generatedGrid = new int[tileNumber * tileNumber];
    GameObject[,] boardArray = new GameObject[tileNumber, tileNumber];

    //public GameObject tile;

    // Use this for initialization
    void Start()
    {
        tempRandom();
        GenerateGrid();
    }

    void tempRandom()
    {
        for (int i = 0; i < generatedGrid.GetLength(0); i++)
        {
            generatedGrid[i] = (int)Random.Range(0, 3);
        }
    }

    void GenerateGrid()
    {
        for (int i = 0; i < boardArray.GetLength(0); i++)
        {
            for (int j = 0; j < boardArray.GetLength(1); j++)
            {
                boardArray[i, j] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                boardArray[i, j].transform.position = new Vector3(i * tileSize, this.transform.position.y, j * tileSize);
                //boardArray[i, j] = Instantiate(tile, new Vector3(j * tileSize, 0, i * tileSize), Quaternion.identity) as GameObject;
                boardArray[i, j].name = "cell" + i + j;
                boardArray[i, j].transform.parent = this.transform;

                rend = boardArray[i, j].GetComponent<Renderer>();

                switch (generatedGrid[j + i * tileNumber])
                {
                    case 0:
                        rend.material.SetColor("_Color", Color.black);
                        break;
                    case 1:
                        rend.material.SetColor("_Color", Color.blue);
                        break;
                    case 2:
                        rend.material.SetColor("_Color", Color.green);
                        break;
                    default:
                        rend.material.SetColor("_Color", Color.gray);
                        break;
                }
            }
        }
    }
}
