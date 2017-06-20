using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelConverterManager : MonoBehaviour {

    //Grab data from the level editor
    private int[,] readyGrid;
    public float waitTime;
    public Grid getGridScript;

    public int tilezise;
    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start() {
        getGridScript = GameObject.Find("Grid").GetComponent<Grid>();

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
	
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.P))
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Destroy(gameObject); //temp solution destroying this object to prevent double ones --- Goal is to prevent loosing grid data and put it back in the editor tool without loosing this object.
        }
    }


    public void StartConversion()
    {

        //1 Convert button is pushed and starts sending the generated data an other 2d array for shipment.
        readyGrid = getGridScript.GetGrid();

        //2 the new game scene loads
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        //3 start placing a grid on the level by showing all the 16x16 cells ( 256 total)
        InstantiateNewGroundGrid();

        //4 Start converting each cell to the gameobject that it needs to be.
        StartCoroutine(WaitLoadingTime());


        //5 Load in the manager prefabs


    }

    public void InstantiateNewGroundGrid()
    {

    }

    IEnumerator WaitLoadingTime()
    {
        
        yield return new WaitForSeconds(waitTime);
        SpawnProps getSpawnScript = GameObject.Find("ShowNewGridObjects").GetComponent<SpawnProps>();
        getSpawnScript.PlaceGridData(tilezise, readyGrid, transform);
    }



}
