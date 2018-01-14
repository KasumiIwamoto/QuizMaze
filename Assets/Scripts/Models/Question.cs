using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Question {

	public int id;
	public string
		body,
		correct,
		choices1,
		choices2,
		choices3,
		kaisetsu;
		

	public void SetData (string[] data) {
		id = int.Parse(data[0]);
		body = data[1];
		correct = data[2];
		choices1 = data[3];
		choices2 = data[4];
		choices3 = data[5];
		kaisetsu = data[6];
	}

}
