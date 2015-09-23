using UnityEngine;
using System.Collections;

public class OrePhysics : MonoBehaviour {
	public int speed;
	private float rndNumber;
	private Vector3 objectPos;

	// Use this for initialization
	void Start () {
		rndNumber = Random.Range (1f, 1f);


		/*float tempX, tempY, tempZ = 0;
		tempX = transform.localPosition.x;
		tempX += rndNumber;


		tempY = transform.localPosition.y;
		tempY += rndNumber;

		tempZ = transform.localPosition.z;
		tempZ += rndNumber;
*/
		objectPos = new Vector3 (rndNumber,rndNumber,rndNumber);
		Rigidbody.position = objectPos;
	/*
		transform.position = objectPos;
	*/
		gameObject.transform.position = new Vector3 (rndNumber, rndNumber, rndNumber);
		transform.Translate(Vector3.up * speed * Time.deltaTime);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		transform.Translate(Vector3.left * speed * Time.deltaTime);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
