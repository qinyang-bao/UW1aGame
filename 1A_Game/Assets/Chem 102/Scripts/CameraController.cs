﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	//private Vector2 moveTemp;

	//public float speed_x;
	//public float speed_y;
	//private float xDifference;
	//private float yDiffernece;
	//public float movementThreshold;

	void Update () {

		transform.position = player.position;
		transform.position = new Vector3 (transform.position.x, transform.position.y, -10f);

		/*xDifference = Mathf.Abs(player.transform.position.x - transform.position.x);
		yDiffernece = Mathf.Abs(player.transform.position.y - transform.position.y);

		if (xDifference >= movementThreshold)
		{
			moveTemp = player.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, moveTemp, speed_x*Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, -10f);
		}

		if (yDiffernece >= movementThreshold) 
		{
			moveTemp = player.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, moveTemp, speed_y*Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, -10f);
		}
		*/

	}
}

