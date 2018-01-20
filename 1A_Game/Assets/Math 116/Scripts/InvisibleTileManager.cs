using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InvisibleTileManager : MonoBehaviour {

	public GameObject[] tiles;
	//public AndrewController andrew;
	private bool is_curr_op = false;
	public bool is_first_tile;

	public int length;

	void Start () {
		//andrew.CorrectPath.Add (gameObject);
		DrawWall (transform.position, length);


		if (!is_first_tile) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	 void LayoutObjectAtRandom(GameObject[] tileArray, int ObjectCount, Vector3 start_pos)
	{
		
		for (int count = 0; count < ObjectCount; count++) {
			Vector3 position = new Vector3 (start_pos.x + count, start_pos.y);
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];

			//make sure operator and variables alternate one by one
			if (count == 0) {
				if (tileChoice.gameObject.CompareTag ("Operators")) {
					is_curr_op = true;
				} else {
					is_curr_op = false;
				}
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

				//except for the first tile, all other tiles are invisible
				tileChoice.GetComponent<SpriteRenderer> ().enabled = false;
			}
			Instantiate (tileChoice, position, Quaternion.identity);
		}

	}

	 void DrawWall(Vector3 start_pos, int length) 
	{
		LayoutObjectAtRandom (tiles, length, start_pos);
	}
}
