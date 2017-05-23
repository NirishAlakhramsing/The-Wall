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

    // Use this for initialization
    void Start () {
	    selector = GameObject.CreatePrimitive(PrimitiveType.Plane);
        rend = selector.GetComponent<Renderer>();
        rend.material = selectMatEmpty;
        selector.transform.parent = transform;
    }

	// Update is called once per frame
	void Update () {
        if (isVisible)
            selector.GetComponent<MeshRenderer>().enabled = true;
        else
            selector.GetComponent<MeshRenderer>().enabled = false;

        var hitInfo = new RaycastHit();

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            if (hitInfo.transform.gameObject.tag == "cell")
            {
                isVisible = true;

                transform.position = new Vector3(hitInfo.transform.position.x, 50, hitInfo.transform.position.z);
            }
        }
        else
            isVisible = false;
    }
    public void swapSelectorColor(int color)
    {
        switch (color)
        {
            case 0:
                rend.material = selectMatWater;
                break;
            case 1:
                rend.material = selectMatGrass;
                break;
            case 2:
                rend.material = selectMatTrees;
                break;
            default:
                rend.material = selectMatEmpty;
                break;
        }
    }
}
