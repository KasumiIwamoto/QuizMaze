using UnityEngine;

public class MakeQuestionCube : MonoBehaviour {

	public int id;
	private bool isMade = false;

	private void OnTriggerEnter (Collider other) {
		if (isMade) return;
		if (other.gameObject.tag == "Player") {
			QuizManager.instance.Show(id);
			isMade = true;
		}
	}

}
