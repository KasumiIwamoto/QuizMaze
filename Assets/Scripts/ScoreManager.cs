using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager 
: SingletonMonoBehaviour<ScoreManager> {

	public Text scoreLabel;
	public int _score = 0;

	// Use this for initialization
	void Start () {
		_score = 0;
		scoreLabel.text ="Score :"+ _score + "点";
	}	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore (int score) {
		_score += score;
		scoreLabel.text ="Score :"+ _score + "点";
	}
}
