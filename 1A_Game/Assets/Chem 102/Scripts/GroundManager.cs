using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

	public BoardManager boardScript;
	public int length;

	void Awake()
	{
		boardScript.DrawGround (transform.position, length);
	}
}
