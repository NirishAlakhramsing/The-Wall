using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text oreText;
	public Text brickText;
	public Text wallText;
	public Text endText;
	public Text introText;
	public Text neOreText;
	public Text neBricksText;

	public string ore, brick, wall, win, lose, intro, neOre, neBricks;
	public int oreAmount, brickAmount, wallAmount;
	public GameObject UICanvas;

	void Awake(){
		//oreText = UICanvas.GetComponentInChildren<Text>();
		//brickText = UICanvas.GetComponentInChildren<Text>();
	}


	// Use this for initialization
	void Start () {
		introText.enabled = true;
		endText.enabled = false;
		neOreText.enabled = false;
		neBricksText.enabled = false;
		brickAmount = 55;
		oreAmount = 0;
		wallAmount = 100;

		intro =  "Build and Defend your wall!!!";
		neOre = "Not enough ore";
		neBricks = "";// Not enough bricks
		wall = "Wall = ";
		ore = "Ores * ";
		brick = "Bricks * ";
		win = "You Win!!!";
		lose = "You Lose!!!";
		//oreText.text = ;
		//brickText.text = ore + oreAmount.ToString () +brick + brickAmount.ToString ();

		oreText.text = ore + oreAmount.ToString() ;
		brickText.text = brick + brickAmount.ToString ();
		wallText.text = wall + wallAmount.ToString ()+ "% ";

		StartCoroutine (StartInfo());
	}
	
	// Update is called once per frame
	void Update () {



		if (wallAmount <= 0) {
			endText.enabled= true;
			endText.text = lose;
			endText.color = Color.red;
		} else {
			endText.text = " ";
		}

		if (oreAmount < 0) {
			oreAmount = 0;
		}

		wallText.text = wall + wallAmount.ToString ();
	}

	public void CurrentOreCount(){
		oreText.text = ore + oreAmount.ToString ();
		brickText.text = brick + brickAmount.ToString ();
		wallText.text = wall + wallAmount.ToString ();
	}

	IEnumerator StartInfo(){
		yield return new WaitForSeconds (3);
		introText.enabled = false;
	}

	public void callOreText(){
		StartCoroutine (NotEnoughOre());
	}

	public void callBrickText(){
		StartCoroutine (NotEnougBricks());
	}

	IEnumerator NotEnoughOre(){
		neOreText.enabled = true;
		yield return new WaitForSeconds (2);
		neOreText.enabled = false;
	}

	IEnumerator NotEnougBricks(){
		neBricksText.enabled = true;
		yield return new WaitForSeconds (2);
		neBricksText.enabled = false;
	}
}
