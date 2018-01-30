using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

	public Text timeLabel;
	public float timer = 300f;
	public Image timeupImage;
	public Image RestartImage;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		timeLabel.text = "残り" + timer + "秒";
		timeupImage.enabled = false;
		RestartImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer > 0) {
			timeLabel.text = "残り" + timer.ToString ("f0") + "秒";
		} else {
			timeLabel.text = "残り0秒";
			Time.timeScale = 0;
			//timeup表示
			timeupImage.enabled = true;
			RestartImage.enabled = true;
			if (Input.GetKey (KeyCode.Space)) {
				//リスタート
				// 現在のシーン番号を取得
				int sceneIndex = SceneManager.GetActiveScene().buildIndex;
				// 現在のシーンを再読込する
				SceneManager.LoadScene(sceneIndex);
			}
		}
	}
}
