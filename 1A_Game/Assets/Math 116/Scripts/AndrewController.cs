using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewController : MonoBehaviour {

	//public List<GameObject> CorrectPath = new List<GameObject>();
	public GameObject [] CorrectPath;
	public Transform player;

	private int currentIndex = 0;

	public float speed = 1f;
	public float y_offset = 1f;
	public float TOL = 0.01f;
	public float PLAYER_TOL = 1.5f;

	private bool travelling = false;
	private bool reached_end = false;

	void Start () {
		transform.position = new Vector2 (CorrectPath[currentIndex].transform.position.x, CorrectPath[currentIndex].transform.position.y + y_offset);

		for (int index = 0; index < CorrectPath.Length; index++) {
			CorrectPath[index].SetActive (false);
		}
	}


	void Update () {

		if (!reached_end) {
			if (CorrectPath [currentIndex].activeSelf) {
				travelling = true;
				currentIndex++;
			}

			if (travelling) {
				//when travelling is true, the index has already been added one
				Vector2 move_to = new Vector2 (CorrectPath [currentIndex].transform.position.x, CorrectPath [currentIndex].transform.position.y + y_offset);
				transform.position = Vector2.MoveTowards (transform.position, move_to, speed * Time.deltaTime);
			}
			
			if (travelling && Mathf.Abs (CorrectPath [currentIndex].transform.position.x - transform.position.x) <= TOL) {
				travelling = false;
			}
			
			//if the player is close enough, move to the next position
			if (Mathf.Abs (player.position.x - (transform.position.x + 41f)) <= PLAYER_TOL && !travelling) {
				CorrectPath [currentIndex].SetActive (true);
			}

			if (currentIndex == CorrectPath.Length - 1 && !travelling) {
				reached_end = true;
			}
		}
	}


}
