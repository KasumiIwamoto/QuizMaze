using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;
using System.Text;

public class GameController : MonoBehaviour {
	int[] array;
	//int[] quiz;
	public Material mat;
	//int[] ary = new int[398];

	//public Text Quiz;

	// Use this for initialization
	void Start () {
		//初期化
		array = new int[400];
		//quiz = new int[10];

		//csvファイルを読んで、配列に格納
		string[] g = ReadCSV ();

		//intがたにcastしてる
		for (int i = 0; i < 400; i++)
			array [i] = int.Parse (g [i]);

		//ゲームオブジェクトの配列の生成
		GameObject[] cube = new GameObject[400]; //ゲームオブジェクト
		String s = "";
		for (int i = 0; i < 400; i++) {
			s = "Cube" + i;
			cube [i] = GameObject.Find (s);
		}

		//ゲームオブジェクトの表示非表示を決めてる
		//int j = 0;
		for (int i = 0; i < 400; i++) {
			if (array [i] == 0)
				cube[i].SetActive (false);
			if (array [i] >= 100) {
				//cubeのマテリアルを透明のものに変更する
				cube[i].GetComponent<Renderer>().material = mat;
				//透明にしたもののコライダーをisTriggerにする
				//コライダーの当たり判定をぶつかったかどうかのみ
				cube[i].GetComponent<BoxCollider>().isTrigger = true;
				//quiz [j++] = array [i];
			}
		}
	}
		
	static string[] ReadCSV(){
		string filePath = @"Assets/maze001.csv";
		string[] cols = new string[400];
		StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));
		while (reader.Peek() >= 0) {
			cols = reader.ReadLine().Split(',');
			/*for (int n = 0; n < cols.Length; n++)
				print (cols [n]);*/
		}
		reader.Close();
		return cols;
	}
}
