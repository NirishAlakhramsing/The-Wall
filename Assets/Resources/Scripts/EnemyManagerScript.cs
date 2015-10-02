using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour {

	private int Wave, spawnTime;
	public bool startWave;
	private Vector3 enemyProximityMin, enemyProximityMax, randSpawnPosition;
	private float rndXposition, rndZposition;
	public GameObject enemyPrefab;


	// Use this for initialization
	void Start () {
		Wave = 4;
		startWave = true;
		spawnTime = 5;

		randSpawnPosition = transform.position;
		
		enemyProximityMin = new Vector3(-40f, 0.0f, 2.5f);
		enemyProximityMax = new Vector3 (-40f, 0.0f, -22.5f);
	}
	
	// Update is called once per frame
	void Update () {
	



		if (startWave && (Wave > 0)) {
			StartCoroutine(SpawnWave());
			startWave= false;
		}
	}

	IEnumerator SpawnWave(){
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(spawnTime);

			Instantiate (enemyPrefab, GetPosition(randSpawnPosition), Quaternion.identity);
		}

		Wave--;
		spawnTime--;
		startWave = true;
	}


	Vector3 GetPosition(Vector3 OldPosition){
		
		rndXposition = Random.Range (enemyProximityMin.x, enemyProximityMax.x);
		rndZposition = Random.Range (enemyProximityMin.z, enemyProximityMax.z);
		
		OldPosition = new Vector3 (rndXposition, 0.5f, rndZposition);
		
		return OldPosition;
	}
}
