using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public float speed;
    public int timer;
    private Mine minescript;
    private UIManagerScript uiscript;
    GameObject getWallObj;
    RaycastHit hit;
    private float dist = 5.00f;

    void Start() {
        minescript = GameObject.Find("ClickBoxVein").GetComponent<Mine>();
        uiscript = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        getWallObj = GameObject.Find("The Wall");

        StartCoroutine(DeathTimer());

        //When spawned target the wall and round it to one of the 90degrees angles
        Debug.Log(getWallObj.transform.position);

        //1 look at the wall axisDirection
        transform.LookAt(getWallObj.transform.position);

        //2 recorrect the distance to ground
        RaycastHit hit;

        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, dist))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            var posY = transform.position.y;
            transform.position = new Vector3(transform.position.x, posY - hit.distance + 0.5f, transform.position.z);
        }
        else {
            //nothing was below your enemy gameObject.
        }

        //3 recorrect the looking angle to straight forward
        var xRotation = transform.eulerAngles.x;
        //xRotation = ClampEulerAngle(xRotation);

        var yRotation = transform.eulerAngles.y;
        //yRotation = ClampEulerAngle(yRotation);

        var zRotation = transform.eulerAngles.z;
        //zRotation = ClampEulerAngle(zRotation);

        transform.eulerAngles = new Vector3(0, -180, zRotation); //FIX ME: ATM HARDCODED - NEEDS TO CLAMP TO ITS NEAREST 90 DEGREES PER STEP VALUE.
    }

	void FixedUpdate() {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
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


    private float ClampEulerAngle(float originalRot)
    {
        var axisDirection = (int)originalRot;
        Debug.Log(axisDirection);

        var negativeDist = 0;
        //negative distance
        for (int i = 0; i < 360; i++)
        {
            //checks if the currentrotation is equal to one of the clamps numbers
            if (axisDirection == ClampNumbers(axisDirection, originalRot))
            {
                //if it is than this axis - origianl = the new negtaive value.
                if (negativeDist <= axisDirection - (int)originalRot)
                {
                    negativeDist = axisDirection - (int)originalRot;
                }
                Debug.Log(negativeDist);
                
            } else
            {
                axisDirection++;
            }
        }

        //positive distance


        //Get the closest


        return axisDirection;
    }

    private int ClampNumbers(int iteration, float original )
    {
     
        switch (iteration)
        {
            case 0:
                iteration = 0;
                break;
            case 90:
                iteration = 90;
                break;
            case 180:
                iteration = 180;
                break;
            case 270:
                iteration = 270;
                break;
            case 360:
                iteration = 360;
                break;
            default:
                //nothing at clamp number
                break;
        }
        return iteration;
    }
}
