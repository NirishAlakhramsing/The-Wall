using UnityEngine;
using System.Collections;

public class OrePhysics : MonoBehaviour {
	private float speed;
	private float rndNumber, xNbr, yNbr, zNbr;
	private bool canCollect;
	private Vector3 objectPos;
	private Rigidbody rb;

	public GameObject addOre;
	UIManagerScript uiscript;

	void Awake(){
		addOre = GameObject.Find("UIManager");
		uiscript = addOre.GetComponent<UIManagerScript> ();
	}

	// Sends the chunks flying off different directions.
	void Start () {
		canCollect = false;

		rb = GetComponent<Rigidbody>();
		speed = 100f;

		for (int i = 0; i < 3; i++) {
			rndNumber = Random.Range (-0.75f, 0.75f);

			if ( i == 0){
				xNbr = rndNumber;
			}

			if (i == 2) {
				zNbr = rndNumber;
			}
		}

		objectPos = new Vector3 (xNbr, 1f , zNbr);
		transform.position = transform.position + objectPos;
		rb.AddForce(objectPos * speed);
	}
	

	void FixedUpdate () {

		//spins the ore chunks in the air.
		if (transform.position.y > 1f){
			transform.Rotate (15f, 0, 15f);
		} else {
		}

		if (Input.GetMouseButtonDown(0) && canCollect == true) {

			uiscript.oreAmount++ ;
			uiscript.CurrentOreCount();

			Destroy(gameObject);
		}
	}

	void OnMouseEnter() {
		canCollect = true;
	}
	
	void OnMouseExit() {
		canCollect = false;
	}


}
