using UnityEngine;

public class MakeQuestionCube : MonoBehaviour {

	public int id;
	[SerializeField] private Material madeMaterial;

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			QuizManager.instance.Show(id);
			GetComponent<Renderer>().material = ResourceManager.instance.madeMaterial;
			Destroy(this);
		}
	}

}
