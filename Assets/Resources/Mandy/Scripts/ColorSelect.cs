using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelect : MonoBehaviour {
    int color = -1;
    GameObject gridObject;


    void Start()
    {
        gridObject = GameObject.Find("Grid");
    }

    public void treeButtonPressed()
    {
        color = 0;

    }

    public void grassButtonPressed()
    {
        color = 1;
    }

    public void waterButtonPressed()
    {
        color = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "cell")
                {

                    switch (color)
                    {
                        case 0:
                            hitInfo.transform.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().trees;
                            break;
                        case 1:
                            hitInfo.transform.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().grass;
                            break;
                        case 2:
                            hitInfo.transform.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().water;
                            break;
                        default:
                            hitInfo.transform.GetComponent<Renderer>().material = gridObject.GetComponent<Grid>().empty;
                            break;
                    }

                }
            }
        }

    }
}

