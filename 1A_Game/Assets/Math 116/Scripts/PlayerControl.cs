using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : PhysicalObject {

	public float jumpTakeOfSpeed = 5;
	public float maxSpeed = 5;

	//private SpriteRenderer spriteRenderer;
	private bool die = false;
	private bool jump;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}


	protected override void GetOtherInput()
	{
		/* if (gc.score == 0) 
		{
			die = true;
		}
		*/

		/*
		if (transform.position.y <= -25f) {
			die = true;
		}
		*/

		//animator.SetBool ("Die", die);
	}


	protected override void ComputeVelocity ()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			velocity.y = jumpTakeOfSpeed;
			jump = true;
		} 
		else if (Input.GetButtonUp ("Jump")) 
		{
			jump = false;

			if (velocity.y > 0) 
			{
				velocity.y = velocity.y * 0.5f;
			}
		}

		if (animator.GetBool("Die")) 
		{
			move = Vector2.zero;
			velocity = Vector2.zero;
		}
			
		targetedVelocity = move * maxSpeed;

		animator.SetBool ("grounded", grounded);
		animator.SetBool ("jump", jump);
		animator.SetFloat ("speed", velocity.x);
	}

}
