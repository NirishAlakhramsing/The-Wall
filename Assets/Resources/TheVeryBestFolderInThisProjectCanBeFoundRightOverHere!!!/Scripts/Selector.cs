using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
    
  /*  public Material selectMat;

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
        //if (isVisible)
            //selector.GetComponent<MeshRenderer>().enabled = true;
        //else
            //selector.GetComponent<MeshRenderer>().enabled = false;

        var hitInfo = new RaycastHit();
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            if (hitInfo.transform.gameObject.tag == "cell")
            {
                isVisible = true;
                // to do code
                transform.position = new Vector3(hitInfo.transform.position.x, 30, hitInfo.transform.position.z);
                Debug.Log(transform.position);
            }

            isVisible = false;
        }
     */
}
