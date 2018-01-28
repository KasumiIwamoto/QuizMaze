using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSphere : MonoBehaviour {

	void OnCollisionEnter (Collision hit){
		// 接触対象はPlayerタグ
		if (hit.gameObject.CompareTag ("Player")) {
			QuizManager.instance.ShowHint();
			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
			//ScoreManager.score += 5;
		}
	}
}
