using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public Material selectMatWater;
    public Material selectMatGrass;
    public Material selectMatTrees;
    public Material selectMatEmpty;
    
    public Material selectMat;

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

        colorize(cellTransform);
    }

    private Material swapSelectorColor(int selColor)
    {
        Material mat;

        switch (selColor)
        {
            case 2:
                mat = selectMatWater;
                break;
            case 1:
                mat = selectMatGrass;
                break;
            case 0:
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
        color = 0;
    }

    public void grassButtonPressed() //mandy
    {
        color = 1;
    }

    public void waterButtonPressed() //mandy
    {
        color = 2;
    }

    void colorize(Transform cell) //mandy
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("works " + cell.GetComponent<Renderer>().material);
            switch (color)
            {
                case 0:
                    cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().trees;
                    break;
                case 1:
                    cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().grass;
                    break;
                case 2:
                    cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().water;
                    break;
                default:
                    cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().empty;
                    break;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            cell.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().empty;
        }

    }
}
