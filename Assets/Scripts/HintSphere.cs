using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSphere : MonoBehaviour {
	//public GameObject particle;

	void OnCollisionEnter (Collision hit){
		// 接触対象はPlayerタグ
		if (hit.gameObject.CompareTag ("Player")) {
			QuizManager.instance.ShowHint();
			//Instantiate (particle, transform.position, transform.rotation);
			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
		}
	}
}
