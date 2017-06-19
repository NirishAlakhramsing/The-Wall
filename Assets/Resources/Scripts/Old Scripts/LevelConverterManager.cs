using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelConverterManager : MonoBehaviour {

    //Grab data from the level editor
    private int[,] readyGrid;

    public Grid getGridScript;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start() {
        
        //Fill the list with empty objects to prevent errors
        readyGrid = new int[getGridScript.getData(), getGridScript.getData()];

        for (int i = 0; i < getGridScript.GetGrid().GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.GetGrid().GetLength(1); j++)
            {//COLLUM
                readyGrid[i, j] = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartConversion()
    {

        //1 Convert button is pushed and starts sending the 2d array data to this script.
        for (int i = 0; i < getGridScript.GetGrid().GetLength(0); i++)
        {//ROW
            for (int j = 0; j < getGridScript.GetGrid().GetLength(1); j++)
            {//COLLUM
                readyGrid[i, j] = getGridScript.GetGrid()[i, j];
            }
        }

        //2 the new game scene loads
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        //3 start placing a grid on the level by showing all the 16x16 cells ( 256 total)


        //4 Start converting each cell to the gameobject that it needs to be.

        //5 Load in the manager prefabs


    }

    public GameObject[,] instantiateGridData(int size, int[,] genGrid, Transform parent)
    {
        GameObject[,] gridObjects = new GameObject[getGridScript.getData(), getGridScript.getData()];

        for (int i = 0; i < gridObjects.GetLength(0); i++)
        {
            /*for (int j = 0; j < gridObjects.GetLength(1); j++)
            {
                gridObjects[i, j] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                gridObjects[i, j].transform.position = parent.position + new Vector3(i * size, this.transform.position.y, j * size);
                gridObjects[i, j].name = "cell" + i.ToString("00") + j.ToString("00");
                gridObjects[i, j].tag = "cell";
                gridObjects[i, j].transform.parent = parent;
                gridObjects[i, j].transform.localScale = new Vector3(0.1f * size, 1, 0.1f * size);

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
            }*/
        }

        return gridObjects;
    }

}
