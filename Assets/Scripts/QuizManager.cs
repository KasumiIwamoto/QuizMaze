using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.UI;

public class QuizManager 
: SingletonMonoBehaviour<QuizManager> {

	public GameObject questionPanel, resultPanel;
	public TextAsset questionCsv;
	public Text questionBodyLabel, resultLabel, kaisetsuLabel;
	public Button resultCloseButton;
	public Choices[] choices;

	private Question currentQuestion;
	private int questionNumber = 0;

	[SerializeField]
	private List<Question> quizzes = new List<Question>();
	public List<Question> LoadedQuizzes {
		get {
			return quizzes;
		}
	}
	
	public void Start () {
		questionPanel.SetActive(false);
		resultCloseButton.onClick.AddListener(() => {
			resultPanel.SetActive(false);
			questionPanel.SetActive(false);
		});
		resultPanel.SetActive(false);
		var csvString = questionCsv.text;
		var csv = CSVReader.SplitCsvGrid(csvString);
		for (int i=1; i<csv.GetLength(1)-1; i++) 
		{
			var data = new Question();
			data.SetData( GetRaw(csv, i) );
			quizzes.Add(data);
		}
		quizzes = quizzes.OrderBy(i => Guid.NewGuid()).ToList();
	}

	private string[] GetRaw (string[,] csv, int row) {
		string[] data = new string[ csv.GetLength(0) ];
		for (int i=0; i<csv.GetLength(0); i++) {
			data[i] = csv[i, row];
		}
		return data;
	}

	public void Show (int wallId) {
		questionPanel.SetActive(true);
		currentQuestion = quizzes[questionNumber];
		questionNumber += 1;
		Dev.JsonLog(currentQuestion);
		questionBodyLabel.text = currentQuestion.body;
		var choicesData = new List<string>();
		choicesData.Add(currentQuestion.correct);
		choicesData.Add(currentQuestion.choices1);
		choicesData.Add(currentQuestion.choices2);
		choicesData.Add(currentQuestion.choices3);
		choicesData = choicesData.OrderBy(i => Guid.NewGuid()).ToList();
		for (int i=0; i<choices.Length; i++) {
			choices[i].SetData(choicesData[i]);
		}
	}

	public void SelectAnswer (string answer) {
		resultPanel.SetActive(true);
		kaisetsuLabel.text = currentQuestion.kaisetsu;
		if (currentQuestion.correct == answer) {
			resultLabel.text = "正解！";
		} else {
			resultLabel.text = "不正解!正解は\n" + currentQuestion.correct;
		}
	}
}
