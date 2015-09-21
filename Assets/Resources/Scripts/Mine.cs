using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	private bool canMine;

	// Use this for initialization
	void Start () {
	
		canMine = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0) && canMine == true) {
			transform.localScale -=  new Vector3(0.1f, 0.1f, 0.1f);
		}

	}

	void OnMouseEnter() {
		canMine = true;
	}

	void OnMouseExit() {
		canMine = false;
	}
}
