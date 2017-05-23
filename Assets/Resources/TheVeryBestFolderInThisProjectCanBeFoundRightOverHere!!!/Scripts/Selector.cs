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
        rend.material = swapSelectorColor(-1);
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
                selector.transform.localScale = new Vector3(1, 1, 1);
                selector.transform.localPosition = new Vector3(0, 0, 0);
                rend.material = swapSelectorColor(0);

                transform.position = new Vector3(hitInfo.transform.position.x, 50, hitInfo.transform.position.z);
            }
            else if (hitInfo.transform.gameObject.tag == "altGrid")
            {
                isVisible = true;
                selector.transform.localScale = new Vector3(3.7f, 1, 3.7f);
                selector.transform.localPosition = new Vector3(15, 0, 15);
                rend.material = swapSelectorColor(-1);

                transform.position = new Vector3(hitInfo.transform.position.x, 50, hitInfo.transform.position.z);
            }
        }
        else
            isVisible = false;
    }
    private Material swapSelectorColor(int color)
    {
        Material mat;

        switch (color)
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
}
