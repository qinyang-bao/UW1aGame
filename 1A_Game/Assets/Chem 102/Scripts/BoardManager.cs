using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour {

	public GameObject[] groundTiles;
	public GameObject[] wallTiles;
	public GameObject[] invisibleWalls;

	public int rows;
	public int columns;

	void LayoutObjectAtRandom(GameObject[] tileArray, int ObjectCount, Vector3 start_pos, bool is_invisible)
	{
		for (int count = 0; count < ObjectCount; count++) {
			
			Vector3 position = new Vector3 (start_pos.x + count, start_pos.y);
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];

			if (is_invisible) 
			{
				tileChoice.GetComponent<SpriteRenderer> ().enabled = false;
			}

			Instantiate (tileChoice, position, Quaternion.identity);


		}

	}

	public void DrawGround(Vector3 start_pos, int length)
	{
		LayoutObjectAtRandom (groundTiles, length, start_pos, false);
		LayoutObjectAtRandom (groundTiles, length, (start_pos - new Vector3(0f, 1f, 0f)), false);
	}

	public void DrawWall(Vector3 start_pos, int length)
	{
		LayoutObjectAtRandom (wallTiles, length, start_pos, false);
	}

	public void DrawInvisibleWall(Vector3 start_pos, int length)
	{
		LayoutObjectAtRandom (invisibleWalls, length, start_pos, true);
	} 
		
}
