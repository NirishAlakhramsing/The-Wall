using UnityEngine;
using System.Collections;

public class MouseOverEmpty : MonoBehaviour {
	public Renderer rend;

	private bool canPlace;

	private WallCreation getWallScript;

	private GameObject wallCube;
	

	// Use this for initialization
	void Start () {
		getWallScript = GameObject.Find("WallCreationManager").GetComponent<WallCreation>();

		rend = GetComponent<Renderer>();

		rend.enabled = false;
		canPlace = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && canPlace == true) {
			//Debug.Log ("Pressed left click.");
			CreateObj ();
			canPlace = false;
		}

		if (Input.GetMouseButtonDown (1)) {
			//Debug.Log ("End of right click");
		}
		
		if (Input.GetMouseButtonDown (2)) {
			//Debug.Log("Pressed middle click.");
		}
	}

	//Lights up a build location on the wall and prevents multiple instances.
	void OnMouseEnter() {
		rend.enabled = true;
		canPlace = true;
	}

	void OnMouseExit() {
		rend.enabled = false;
		canPlace = false;
	}

	// Puts the a wall part on its right location
	public void CreateObj (){

		if (gameObject.name == "EmptyLocation") {
			wallCube = getWallScript.prefabCube[0];
		}

		if (gameObject.name == "EmptyLocation2") {
			wallCube = getWallScript.prefabCube[1];
		}

		if (gameObject.name == "EmptyGate") {
			wallCube = getWallScript.prefabCube[2];
		}

		Instantiate (wallCube, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}


}
