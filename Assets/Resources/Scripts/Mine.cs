using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	private bool canMine;
	private GameObject oreChunk;

	public GameObject[] oreTypes;

	// Use this for initialization
	void Start () {
		oreChunk = oreTypes[0];
		canMine = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0) && canMine == true) {
			transform.localScale -=  new Vector3(0.1f, 0.1f, 0.1f);
			CreateOreChunks();
		}
	}

	void OnMouseEnter() {
		canMine = true;
	}

	void OnMouseExit() {
		canMine = false;
	}

	public void CreateOreChunks(){
		Instantiate (oreChunk, transform.position, Quaternion.identity);
	}
}
