using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text timeLabel;
	float timer = 300f;

	// Use this for initialization
	void Start () {
		timeLabel.text = "残り" + timer + "秒";

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		timeLabel.text = "残り" + timer.ToString("f2") + "秒";
	}
}
