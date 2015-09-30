using UnityEngine;
using System.Collections;

public class MouseOverEmpty : MonoBehaviour {
	private Renderer rend;

	private bool canPlace;
	public bool blockT1, blockT2, gateT1;
	private WallCreation getWallScript;

	public GameObject wallCube;

	public GameObject addOre;
	UIManagerScript uiscript;

	// Use this for initialization
	void Start () {


		//blockT1 = false;
		blockT2 = false;
		gateT1 = false;

		addOre = GameObject.Find("UIManager");
		uiscript = addOre.GetComponent<UIManagerScript> ();

		getWallScript = GameObject.Find("WallCreationManager").GetComponent<WallCreation>();

		rend = GetComponent<Renderer>();

		rend.enabled = false;
		canPlace = false;

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (blockT1);

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

		if ((gameObject.name == "EmptyLocation") && (getWallScript.blockT1 == true)) {
			wallCube = getWallScript.prefabCube[0];
			uiscript.brickAmount -= 5;
			Instantiate (wallCube, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

		if ((gameObject.name == "EmptyLocation2") && (getWallScript.blockT2 == true)) {
			wallCube = getWallScript.prefabCube[1];
			uiscript.brickAmount -= 10;
			Instantiate (wallCube, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

		if ((gameObject.name == "EmptyGate") && (getWallScript.gateT1 == true)) {
			wallCube = getWallScript.prefabCube[2];
			uiscript.brickAmount -= 15;
			Instantiate (wallCube, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}


	}



}
