using UnityEngine;
using System.Collections;

public class OreVeinManagerScript : MonoBehaviour {

	public GameObject vein;
	private int maxVeins, veinCount;

	// Use this for initialization
	void Start () {
		maxVeins = 5;
		StartCoroutine (SpawnVein());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawnVein(){
		yield return new WaitForSeconds(5);
		Instantiate (vein, transform.position, Quaternion.identity);
		veinCount++;

		if (veinCount != maxVeins) {
			StartCoroutine (SpawnVein ());
		}
	}



}
