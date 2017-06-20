using UnityEngine;
using System.Collections;

public class SpawnProps : MonoBehaviour {

    public GameObject water;
    public GameObject grass;
    public GameObject tree;


    public GameObject[,] PlaceGridData(int size, int[,] genGrid, Transform parent)
    {
        GameObject[,] gridObjects = new GameObject[genGrid.GetLength(0), genGrid.GetLength(1)];

        for (int i = 0; i < gridObjects.GetLength(0); i++)
        {
            for (int j = 0; j < gridObjects.GetLength(1); j++)
            {

                switch (genGrid[i, j])
                {
                    case 0:
                        gridObjects[i, j] = Instantiate(water);
                        gridObjects[i, j].transform.position = parent.position + new Vector3((i * size), this.transform.position.y, j * size);
                        gridObjects[i, j].name = "cell" + i.ToString("00") + j.ToString("00");
                        gridObjects[i, j].tag = "cell"; //tag for the cell
                        gridObjects[i, j].transform.parent = parent;
                        gridObjects[i, j].transform.localScale = new Vector3(6.010375f, gridObjects[i, j].transform.localScale.y, 6.010375f);
                        break;
                    case 1:
                        gridObjects[i, j] = Instantiate(grass);
                        gridObjects[i, j].transform.position = parent.position + new Vector3(i * size + Random.Range(-0.50f, 0.50f), this.transform.position.y, j * size + Random.Range(-0.50f, 0.50f));
                        gridObjects[i, j].name = "cell" + i.ToString("00") + j.ToString("00");
                        gridObjects[i, j].tag = "cell"; //tag for the cell
                        gridObjects[i, j].transform.parent = parent;
                        gridObjects[i, j].transform.localScale = new Vector3(Random.Range(30f, 50f), Random.Range(30f, 50f), Random.Range(20f, 40f));
                        gridObjects[i, j].transform.localEulerAngles = new Vector3(-90f, -132.9858f, Random.Range(0f, 360f));
                        break;
                    case 2:
                        gridObjects[i, j] = Instantiate(tree);
                        gridObjects[i, j].transform.position = parent.position + new Vector3(i * size + Random.Range(-2.50f, 2.50f), this.transform.position.y, j * size + Random.Range(-2.50f, 2.50f));
                        gridObjects[i, j].name = "cell" + i.ToString("00") + j.ToString("00");
                        gridObjects[i, j].tag = "cell"; //tag for the cell
                        gridObjects[i, j].transform.parent = parent;
                        gridObjects[i, j].transform.localScale = new Vector3(Random.Range(0.35f, 0.55f), 0.43f, Random.Range(0.35f, 0.7f));
                        break;
                    default:
                        break;
                }
            }
        }

        return gridObjects;
    }
}
