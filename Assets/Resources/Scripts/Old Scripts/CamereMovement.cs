using UnityEngine;
using System.Collections;

public class CamereMovement : MonoBehaviour {
	private Vector3 front, oldPosition , backrot, frontrot;
	
	// Use this for initialization
	void Start () {
		oldPosition = gameObject.transform.position;
		front = new Vector3 (-34, 12, -10);
		backrot = new Vector3 (-90, -30, 0);
		frontrot = new Vector3 ( 90, -45, 0);
		Quaternion rotation = Quaternion.LookRotation (backrot);
		transform.rotation = rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
		StartCoroutine (MoveCamera ());

	}

	IEnumerator MoveCamera(){
		if (Input.GetKeyUp ("right")) {

			Quaternion rotation = Quaternion.LookRotation (frontrot);
			transform.rotation = rotation;
			transform.position = front;
		}

		yield return new WaitForSeconds (1);

		if (Input.GetKeyUp ("left")) {
			Quaternion rotation = Quaternion.LookRotation (backrot);
			transform.rotation = rotation;
			transform.position = oldPosition;
		}
	}
}
