using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	private int miningTimes, miningCount;
	private bool canMine;
	private GameObject oreChunk;



	public GameObject[] oreTypes;

	public GameObject countVein;
	OreVeinManagerScript orescript;

	// Use this for initialization
	void Start () {
		miningCount = 0;

		oreChunk = oreTypes[0];
		canMine = false;
		miningTimes = (int)Random.Range (5, 10);

		countVein = GameObject.Find ("OreVeinManager");
		orescript = countVein.GetComponent<OreVeinManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0) && canMine == true) {
			transform.localScale -=  new Vector3(0.1f, 0.1f, 0.1f);
			CreateOreChunks();
			miningCount++;
		}

		if (miningCount == miningTimes) {

			//orescript.maxVeins--;
			orescript.veinCount--;
			//orescript.startSpawning = true;
			Destroy(gameObject);
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
