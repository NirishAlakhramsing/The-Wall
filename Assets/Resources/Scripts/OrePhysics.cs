using UnityEngine;
using System.Collections;

public class OrePhysics : MonoBehaviour {
	private float speed;
	private float rndNumber, xNbr, yNbr, zNbr;
	private Vector3 objectPos;
	private Rigidbody rb;


	// Use this for initialization
	void Start () {

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
	
	// Update is called once per frame
	void Update () {


	}
}
