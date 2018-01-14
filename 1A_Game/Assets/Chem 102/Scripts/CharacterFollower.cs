using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour {

	public GameObject character;
	public float offset_x;
	public float offset_y;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (character.transform.position.x + offset_x, character.transform.position.y + offset_y);
			
	}
}
