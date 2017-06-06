using UnityEngine;
using System.Collections;

public class AltGrid : MonoBehaviour {

    public const int tileNumber = 16;

    int[,] generatedGrid = new int[tileNumber, tileNumber];
    GameObject[,] altArray0 = new GameObject[tileNumber, tileNumber];
    GameObject[,] altArray1 = new GameObject[tileNumber, tileNumber];
    GameObject[,] altArray2 = new GameObject[tileNumber, tileNumber];
    GameObject[,] altArray3 = new GameObject[tileNumber, tileNumber];
    GameObject[,] altArray4 = new GameObject[tileNumber, tileNumber];
    GameObject[,] altArray5 = new GameObject[tileNumber, tileNumber];

    GameObject[] ArrayParent = new GameObject[6];

    GameObject gridObject;

    // Use this for initialization
    void Start () {
        gridObject = GameObject.Find("Grid");
        createAltGrid();
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

    void createAltGrid()
    {
        var grid = gridObject.GetComponent<Grid>();

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < ArrayParent.Length; i++)
        {
            ArrayParent[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ArrayParent[i].GetComponent<MeshRenderer>().enabled = false;
            ArrayParent[i].transform.tag = "altGrid";
            ArrayParent[i].GetComponent<BoxCollider>().size = new Vector3(36, 1, 36);
            ArrayParent[i].GetComponent<BoxCollider>().center = new Vector3(15, 0, 15);
            ArrayParent[i].transform.parent = transform;
            ArrayParent[i].name = "ArrayParent" + i;
        }

        tempRandom();
        ArrayParent[0].transform.position = transform.position + new Vector3(0, 0, 0);
        altArray0 = grid.generateGrid(2, generatedGrid, ArrayParent[0].transform);

        tempRandom();
        ArrayParent[1].transform.position = transform.position + new Vector3(35, 0, 0);
        altArray1 = grid.generateGrid(2, generatedGrid, ArrayParent[1].transform);

        tempRandom();
        ArrayParent[2].transform.position = transform.position + new Vector3(0, 0, -35);
        altArray2 = grid.generateGrid(2, generatedGrid, ArrayParent[2].transform);

        tempRandom();
        ArrayParent[3].transform.position = transform.position + new Vector3(35, 0, -35);
        altArray3 = grid.generateGrid(2, generatedGrid, ArrayParent[3].transform);

        tempRandom();
        ArrayParent[4].transform.position = transform.position + new Vector3(0, 0, -70);
        altArray4 = grid.generateGrid(2, generatedGrid, ArrayParent[4].transform);

        tempRandom();
        ArrayParent[5].transform.position = transform.position + new Vector3(35, 0, -70);
        altArray5 = grid.generateGrid(2, generatedGrid, ArrayParent[5].transform);
    }
}
