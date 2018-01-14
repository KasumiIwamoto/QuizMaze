using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

	[SerializeField] private TextAsset mazeCsv;
	[SerializeField] private Transform player;
	[SerializeField] private GameObject wallPrefab, itemPrefab;
	[SerializeField] private Vector2 _wallSize = new Vector2(3, 10);
	[SerializeField] private Material questionWallMaterial;

	private const string
		_sign_start = "S",
		_sign_wall = "1",
		_sign_question = "2",
		_sign_item = "3";

	void Start () {
		var csvString = mazeCsv.text;
		var csv = CSVReader.SplitCsvGrid(csvString);
		int questionCubeId = 0;
		for (int x=0; x<csv.GetLength(0); x++) {
			for (int z=0; z<csv.GetLength(1); z++) {
				var sign = csv[x,z];
				var setPosition = new Vector3 ( 
					x * _wallSize.x + transform.position.x,
					transform.position.y,
					z * _wallSize.x + transform.position.z );
				if (sign == _sign_start) {
					player.position = setPosition;
				}
				if (sign == _sign_wall) {
					var wall = Instantiate(wallPrefab);
					wall.transform.localScale = new Vector3(_wallSize.x, _wallSize.y, _wallSize.x);
					wall.transform.position = setPosition;
					wall.transform.SetParent(transform);
				}
				if (sign == _sign_question) {
					var wall = Instantiate(wallPrefab);
					wall.transform.localScale = new Vector3(_wallSize.x, _wallSize.y, _wallSize.x);
					wall.transform.position = setPosition;
					wall.transform.SetParent(transform);
					wall.GetComponent<Renderer>().material = questionWallMaterial;
					wall.GetComponent<BoxCollider>().isTrigger = true;
					var questionCube = wall.AddComponent<MakeQuestionCube>();
					questionCube.id = questionCubeId;
					questionCubeId += 1;
				}
				if (sign == _sign_item) {
					var item = Instantiate(itemPrefab);
					item.transform.position = setPosition + Vector3.up;
					item.transform.SetParent(transform);
				}
			}
		}
	}

}
