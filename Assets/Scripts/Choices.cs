using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {

	public Text choicesLabel;
	public Button button;

	public void Awake () {
		button.onClick.AddListener(() => {
			QuizManager.instance.SelectAnswer(choicesLabel.text);
		});
	}

	public void SetData (string text) {
		choicesLabel.text = text;
	}

}
