using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed;
	public int timer;
	private Mine minescript;
	private UIManagerScript uiscript;


	void Start() {
		minescript = GameObject.Find ("ClickBoxVein").GetComponent<Mine> ();
		uiscript = GameObject.Find ("UIManager").GetComponent<UIManagerScript> ();

		StartCoroutine (DeathTimer ());
	}

	void FixedUpdate() {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Wallpart") {

			minescript.CreateBrickChunks(gameObject.transform.position);
			uiscript.wallAmount -= Random.Range (1,10);
			Destroy (gameObject);
			}

	}

	IEnumerator DeathTimer(){
		yield return new WaitForSeconds(timer);
		Destroy (gameObject);
	}

}
