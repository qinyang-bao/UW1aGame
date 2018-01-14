using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

	public BoardManager boardScript;
	public int length;

	public bool is_invisible;

	void Awake()
	{
		if (!is_invisible) {
			boardScript.DrawWall (transform.position, length);
		} else {
			GetComponent<SpriteRenderer> ().enabled = false;
			boardScript.DrawInvisibleWall (transform.position, length);
		}
	}
}
