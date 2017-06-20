using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_SliderScript : MonoBehaviour {

    public GameObject waterSlider;
    public GameObject treeSlider;
    public GameObject grassSlider;

    public TEST_GrowthGeneration getGrowthScript;

    private Text waterText;
    private Text grassText;
    private Text treeText;

    // Use this for initialization
    void Start () {
        waterText = waterSlider.GetComponent<Text>();
        grassText = grassSlider.GetComponent<Text>();
        treeText = treeSlider.GetComponent<Text>();

        getGrowthScript = GameObject.Find("Grid").GetComponent<TEST_GrowthGeneration>();

	}
	

    public void ChangeWater(float number)
    {
        waterText.text = number.ToString();

        getGrowthScript.waterChanceWater = (int)number;
    }

    public void ChangeGrass(float number)
    {
        grassText.text = number.ToString();

        getGrowthScript.growthChanceGrass = (int)number;
    }

    public void ChangeTree(float number)
    {
        treeText.text = number.ToString();

        getGrowthScript.growthChanceTree = (int)number;
    }
}
