using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InvisibleTileManager : MonoBehaviour {

	public GameObject[] operators;
	public GameObject[] variables;
	//public AndrewController andrewScript;
	public bool is_first_tile;
	//public int path_index;

	public int length;
	public bool to_right = true;

	/*
	void Awake () {
		andrewScript.CorrectPath.
		Insert(path_index, gameObject);
	}
	*/

	void Start()
	{
		DrawWall (transform.position, length);

		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
		

	void LayoutObjectAtRandom(GameObject[] operatorArray, GameObject[] variableArray, int ObjectCount, Vector3 start_pos)
	{
		
		for (int count = 0; count < ObjectCount; count++) {
			Vector3 position = new Vector3 ();
			if (to_right) {
				 position = new Vector3 (start_pos.x + count, start_pos.y);
			} else {
				 position = new Vector3 (start_pos.x - count, start_pos.y);
			}
			GameObject tileChoice;
			if (count % 2 == 0 || count == 0) {
				tileChoice = variableArray [Random.Range (0, variableArray.Length)];
			} else {
				tileChoice = operatorArray [Random.Range (0, operatorArray.Length)];
			}
				
			/*
			//make sure operators and variables alternate one by one
			if (count > 0) {
				tileChoice = tileArray [Random.Range (0, tileArray.Length)];
				is_curr_op = false;
			} else {
				if (is_curr_op && tileChoice.gameObject.CompareTag ("Operators")) {
					while (tileChoice.gameObject.CompareTag ("Operators"))
						tileChoice = tileArray [Random.Range (0, tileArray.Length)];
					is_curr_op = false;
				} else if (!is_curr_op && tileChoice.gameObject.CompareTag ("Variables")) {
					while (tileChoice.gameObject.CompareTag ("Operators"))
						tileChoice = tileArray [Random.Range (0, tileArray.Length)];
					is_curr_op = true;
				}
			}
			*/
			GameObject instance = Instantiate (tileChoice, position, Quaternion.identity);

			//except for the first tile of the entire game, all other tiles are invisible
			instance.GetComponent<SpriteRenderer> ().enabled = false;
			if(is_first_tile && count == 0)
				instance.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void DrawWall(Vector3 start_pos, int length) 
	{
		LayoutObjectAtRandom (operators, variables, length, start_pos);
	}
}
