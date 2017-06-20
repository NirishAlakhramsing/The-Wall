using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public Material selectMatWater;
    public Material selectMatGrass;
    public Material selectMatTrees;
    public Material selectMatEmpty;

    GameObject selector;
    Renderer rend;

    bool isVisible = false;

    int color = -1;              //mandy
    GameObject gridObject;      //mandy
    Transform cellTransform;    //mandy

    // Use this for initialization
    void Start () {
	    selector = GameObject.CreatePrimitive(PrimitiveType.Plane);
        rend = selector.GetComponent<Renderer>();
        rend.material = swapSelectorColor(-1);
        selector.transform.parent = transform;

        gridObject = GameObject.Find("Grid");   //mandy
    }

	// Update is called once per frame
	void Update ()
    {
        if (isVisible)
            selector.GetComponent<MeshRenderer>().enabled = true;
        else
            selector.GetComponent<MeshRenderer>().enabled = false;

        var hitInfo = new RaycastHit();

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            isVisible = true;

            if (hitInfo.transform.gameObject.tag == "cell")
            {
                selector.transform.localScale = new Vector3(1, 1, 1);
                selector.transform.localPosition = new Vector3(0, 0, 0);
                rend.material = swapSelectorColor(color);

                cellTransform = hitInfo.transform;
            }
            else if (hitInfo.transform.gameObject.tag == "altGrid")
            {
                selector.transform.localScale = new Vector3(3.7f, 1, 3.7f);
                selector.transform.localPosition = new Vector3(15, 0, 15);
                rend.material = swapSelectorColor(-1);

                cellTransform = null;
            }

            transform.position = new Vector3(hitInfo.transform.position.x, 50, hitInfo.transform.position.z);
        }
        else
        {
            isVisible = false;
            cellTransform = null;
        }

        if(cellTransform != null)colorize(cellTransform);
    }

    private Material swapSelectorColor(int selColor)
    {
        Material mat;

        switch (selColor)
        {
            case 0:
                mat = selectMatWater;
                break;
            case 1:
                mat = selectMatGrass;
                break;
            case 2:
                mat = selectMatTrees;
                break;
            default:
                mat = selectMatEmpty;
                break;
        }

        return mat;
    }

    public void treeButtonPressed() //mandy
    {
        color = 2;
    }

    public void grassButtonPressed() //mandy
    {
        color = 1;
    }

    public void waterButtonPressed() //mandy
    {
        color = 0;
    }

    void colorize(Transform cell) //mandy
    {
        var grid = gridObject.GetComponent<Grid>();

        if (Input.GetMouseButtonDown(0) && cell != null)
        {
            if (grid.setCellColor(cell.name, color))
            {
                switch (color)
                {
                    case 0:
                        cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().water;
                        break;
                    case 1:
                        cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().grass;
                        break;
                    case 2:
                        cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().trees;
                        break;
                    default:
                        cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().empty;
                        break;
                }
            }

            //grid.setCellColor(cell.name, color);
        }
        else if (Input.GetMouseButtonDown(1) && cell != null)
        {
            if (grid.setCellColor(cell.name, -1))
            {
                cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().empty;
            }
        }

        //gridObject.GetComponent<Grid>().setCellColor(cell.name, color); // set new cell color on the correct cell in the 2D grid
    }
}
