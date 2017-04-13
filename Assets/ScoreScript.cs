using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour {

	//得点を表示するテキスト
	private GameObject PointText;
	private GameObject ScoreText;

	//得点の合計を表示するテキスト
	static int TotalPoint;

	// Use this for initialization
	void Start () {
		this.PointText = GameObject.Find("PointText");
		this.ScoreText = GameObject.Find("ScoreText");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		if (tag == "SmallStarTag") {
			this.PointText.GetComponent<Text> ().text = "point:+5";
			ScoreScript.TotalPoint += 5;
			this.ScoreText.GetComponent<Text> ().text = "Score:" + TotalPoint;

		} else if (tag == "LargeStarTag") {
			this.PointText.GetComponent<Text> ().text = "point:+20";
			ScoreScript.TotalPoint += 20;
			this.ScoreText.GetComponent<Text> ().text = "Score:" + TotalPoint;
		}else if(tag == "SmallCloudTag") {
			this.PointText.GetComponent<Text> ().text = "point:+10";
			ScoreScript.TotalPoint += 10;
			this.ScoreText.GetComponent<Text> ().text = "Score:" + TotalPoint;
		}else if(tag == "LargeCloudTag") {
			this.PointText.GetComponent<Text> ().text = "point:+15";
			ScoreScript.TotalPoint += 15;
			this.ScoreText.GetComponent<Text> ().text = "Score:" + TotalPoint;
		}

	}


}


