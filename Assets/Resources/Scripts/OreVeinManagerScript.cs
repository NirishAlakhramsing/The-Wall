using UnityEngine;
using System.Collections;

public class OreVeinManagerScript : MonoBehaviour {

	public GameObject vein;
	public bool startSpawning;
	private Vector3 veinProximityMin, veinProximityMax, randSpawnPosition;
	private float rndXposition, rndZposition;
	private int maxVeins, veinCount;

	// Use this for initialization
	void Start () {
		startSpawning = false;

		randSpawnPosition = transform.position;

		maxVeins = 5;

		//StartCoroutine (SpawnVein());

		veinProximityMin = new Vector3(-4f, 0.0f, -21);
		veinProximityMax = new Vector3 (2f, 0.0f, 0f);

	}
	
	// Update is called once per frame
	void Update () {

		if (startSpawning) {
			StartCoroutine(SpawnVein());
			startSpawning = false;
		}

	}

	IEnumerator SpawnVein(){

		yield return new WaitForSeconds(5);

		Instantiate (vein, GetPosition(randSpawnPosition), Quaternion.identity);
		veinCount++;

		if (veinCount != maxVeins) {
			StartCoroutine (SpawnVein ());
		}
	}
	
	Vector3 GetPosition(Vector3 OldPosition){

		rndXposition = Random.Range (veinProximityMin.x, veinProximityMax.x);
		rndZposition = Random.Range (veinProximityMin.z, veinProximityMax.z);
	
		OldPosition = new Vector3 (rndXposition, 0.0f, rndZposition);

		return OldPosition;
	}
}
