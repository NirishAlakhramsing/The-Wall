using UnityEngine;
using System.Collections;

public class WallRepairScript : MonoBehaviour {

	private UIManagerScript uiscript;
	private bool canRepair;
	
	// Use this for initialization
	void Start () {
		uiscript = GameObject.Find ("UIManager").GetComponent<UIManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && (uiscript.wallAmount <=99) && (uiscript.brickAmount >= 1) && canRepair) {
			//Debug.Log ("Pressed left click.");

			uiscript.wallAmount ++;
			uiscript.brickAmount --;
		}
	}
	
	void OnMouseEnter() {
		
		canRepair = true;
	}
	
	void OnMouseExit() {
		
		canRepair = false;
	}
}
