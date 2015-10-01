using UnityEngine;
using System.Collections;

public class OreVeinManagerScript : MonoBehaviour {

	public GameObject vein;
	public bool startSpawning, endSpawning;
	private Vector3 veinProximityMin, veinProximityMax, randSpawnPosition;
	private float rndXposition, rndZposition;
	public int maxVeins;
	public int veinCount;

	// Use this for initialization
	void Start () {
		startSpawning = true;
		endSpawning = false;
		//maxVeins = 1;

		randSpawnPosition = transform.position;

		veinProximityMin = new Vector3(-4f, 0.0f, -21);
		veinProximityMax = new Vector3 (2f, 0.0f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
			/*
		if (startSpawning) {
			StartCoroutine(SpawnVein());
			startSpawning = false;
		} */

		if (startSpawning && (veinCount != maxVeins)) {
			StartCoroutine(SpawnVein());
			startSpawning = false;
		}


		if (veinCount == 0 && endSpawning) {
			startSpawning = true;
			endSpawning = false;
		}
	}

	IEnumerator SpawnVein(){

		yield return new WaitForSeconds(5);

		Instantiate (vein, GetPosition(randSpawnPosition), Quaternion.identity);
		veinCount++;


		if (veinCount != maxVeins) {
			StartCoroutine (SpawnVein ());
		} else {
			startSpawning =false;
			endSpawning = true;
		}
	}
	
	Vector3 GetPosition(Vector3 OldPosition){

		rndXposition = Random.Range (veinProximityMin.x, veinProximityMax.x);
		rndZposition = Random.Range (veinProximityMin.z, veinProximityMax.z);
	
		OldPosition = new Vector3 (rndXposition, 0.0f, rndZposition);

		return OldPosition;
	}
}
