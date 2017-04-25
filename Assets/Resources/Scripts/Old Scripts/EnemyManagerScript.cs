using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour {

	private int wave, spawnTime, total;
	public bool startWave;
	private Vector3 enemyProximityMin, enemyProximityMax, randSpawnPosition;
	private float rndXposition, rndZposition;
	public GameObject enemyPrefab;
	private UIManagerScript uiscript;


	// Use this for initialization
	void Start () {
		uiscript = GameObject.Find ("UIManager").GetComponent<UIManagerScript> ();

		wave = 4;
		startWave = true;
		spawnTime = 5;

		total = wave * spawnTime;

		randSpawnPosition = transform.position;
		
		enemyProximityMin = new Vector3(-40f, 0.0f, 2.5f);
		enemyProximityMax = new Vector3 (-40f, 0.0f, -22.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (total == 0) {
			uiscript.endText.text = uiscript.win;
			uiscript.endText.color = Color.cyan;
		}

		if (startWave && (wave > 0)) {
			StartCoroutine(SpawnWave());
			startWave= false;
		}
	}

	IEnumerator SpawnWave(){
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(spawnTime);

			Instantiate (enemyPrefab, GetPosition(randSpawnPosition), Quaternion.identity);
		}

		wave--;
		spawnTime--;
		startWave = true;
		total--;
	}


	Vector3 GetPosition(Vector3 OldPosition){
		
		rndXposition = Random.Range (enemyProximityMin.x, enemyProximityMax.x);
		rndZposition = Random.Range (enemyProximityMin.z, enemyProximityMax.z);
		
		OldPosition = new Vector3 (rndXposition, 0.5f, rndZposition);
		
		return OldPosition;
	}
}
