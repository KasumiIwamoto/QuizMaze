﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision hit){
		// 接触対象はPlayerタグ
		if (hit.gameObject.CompareTag ("Player")) {
			ScoreManager.instance.AddScore(1);
			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
			//ScoreManager.score += 5;
		}
	}
}
