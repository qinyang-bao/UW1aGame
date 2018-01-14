using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewController : MonoBehaviour {

	public GameObject[] CorrectPath;
	public Transform startLocation;

	private int currentIndex = 0;

	private Animator animator;
	private bool fly;

	public float speed;
	public float y_offset;
	private float TOL = 0.01f;


	// Use this for initialization
	void Start () {
		transform.position = startLocation.position;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CorrectPath [currentIndex].activeSelf) {
			Vector2 move_to = new Vector2 (CorrectPath [currentIndex + 1].transform.position.x, CorrectPath [currentIndex + 1].transform.position.y + y_offset);
			transform.position = Vector2.MoveTowards (transform.position, move_to, speed*Time.deltaTime);
			currentIndex++;
			fly = true;
		}

		if (transform.position.x - CorrectPath [currentIndex + 1].transform.position.x <= TOL) {
			fly = false;
		}

		animator.SetBool ("Fly", fly);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player")){
			CorrectPath [currentIndex].SetActive (true);
		}
	}

}
