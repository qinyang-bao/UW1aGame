using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewController : MonoBehaviour {

	public List<GameObject> CorrectPath = new List<GameObject>();
	//public Transform startLocation;

	private int currentIndex = 0;


	public float speed;
	public float y_offset;
	private float TOL = 0.01f;


	// Use this for initialization
	void Start () {
		//transform.position = startLocation.position;
		transform.position = CorrectPath[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (CorrectPath [currentIndex].activeSelf) {
			Vector2 move_to = new Vector2 (CorrectPath [currentIndex + 1].transform.position.x, CorrectPath [currentIndex + 1].transform.position.y + y_offset);
			transform.position = Vector2.MoveTowards (transform.position, move_to, speed*Time.deltaTime);
			currentIndex++;
		}

		if (transform.position.x - CorrectPath [currentIndex + 1].transform.position.x <= TOL) {
			CorrectPath [currentIndex].SetActive (true);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player")){
			CorrectPath [currentIndex].SetActive (true);
		}
	}

}
