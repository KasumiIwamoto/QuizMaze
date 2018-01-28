using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreLabel;
	public int score = 0;

	// Use this for initialization
	void Start () {
		score = 0;
		setScore ();
	}	
	// Update is called once per frame
	void Update () {
		
	}

	public void setScore(){
		scoreLabel.text ="Score :"+ score + "点";
	}
}
