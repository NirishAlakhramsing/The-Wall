using UnityEngine;
using System.Collections;

public class DragPatch : MonoBehaviour {

    /* private float lockYPosition;

    public float moveSpeed;

    void Start()
    {
        lockYPosition = transform.position.y;
    }

    void OnMouseDrag()
    {
        //Drag the patch around the scene over the x and z axis
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, lockYPosition, Input.mousePosition.z);
        //Vector3 patchPosition = Camera.main.ViewportToScreenPoint(mousePosition);

        transform.position = mousePosition;
    }*/

    private Vector3 screenPoint;
    private Vector3 offset;
    private float lockYPosition;

    void Start()
    {
        lockYPosition = transform.position.y;
    }

        void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, lockYPosition, transform.position.z));
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, lockYPosition, screenPoint.z);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, lockYPosition, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, lockYPosition, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = new Vector3(cursorPosition.x, lockYPosition, cursorPosition.z);
    }
}
