using UnityEngine;
using System.Collections;

public class WallCreation : MonoBehaviour {

	public GameObject[] prefabCube;

	public GameObject addOre;
	UIManagerScript uiscript;

	public bool blockT1, blockT2, gateT1;

	
	void Awake(){
		uiscript = GameObject.Find("UIManager").GetComponent<UIManagerScript> ();
	}

	// Use this for initialization
	void Start () {
		blockT1 = false;
		blockT2 = false;
		gateT1 = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (uiscript.brickAmount >= 4) {
			blockT1 = true;
		} else {
			blockT1 = false;
		}
		
		if (uiscript.brickAmount >= 10) {
			blockT2 = true;
		} else {
			blockT2 = false;
		}

		if (uiscript.brickAmount >= 15) {
			gateT1 = true;
		} else {
			gateT1 = false;
		}
	}
}
