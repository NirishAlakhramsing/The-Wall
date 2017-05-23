using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public Material selectMat;

    GameObject selector;
    Renderer rend;

    bool isVisible = false;

    // Use this for initialization
    void Start () {
	    selector = GameObject.CreatePrimitive(PrimitiveType.Plane);
        rend = selector.GetComponent<Renderer>();
        rend.material = selectMat;
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
                // to do code
                transform.position = hitInfo.transform.position;
                //Debug.Log("werkt");
            }
        }
    }
}
