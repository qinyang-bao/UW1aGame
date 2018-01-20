using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {
	
	public float jumpTakeOfSpeed = 5;
	public float maxSpeed = 5;

	//private SpriteRenderer spriteRenderer;
	protected Animator animator;
	private bool die;
	private bool jump;
	protected bool attack_tool;
	private bool attack_iclicker;

	public GameObject iclicker_attack;
	public GameObject iclicker;
	public Transform spawnPos;

	public float attack_rate_iclicker;
	private float next_attack_iclicker;

	public float Xmultiplier = 1f;




	void Awake () {
		//spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		next_attack_iclicker = 0f;

		iclicker.SetActive (false);
	}
		


	protected override void GetOtherInput()
	{
		if (Input.GetButton ("Fire1"))
		{
			attack_tool = true;
		}

		if (!Input.GetButton ("Fire1") && attack_tool)
		{
			attack_tool = false;
		}

		if (Input.GetButton ("Fire2") && Time.time > next_attack_iclicker && iclicker.activeSelf)
		{
			attack_iclicker = true;
			next_attack_iclicker += attack_rate_iclicker;

			GameObject instance = Instantiate (iclicker_attack, spawnPos.position, Quaternion.identity) as GameObject;
			AttackMover script = instance.GetComponent<AttackMover> ();
			script.direction = Vector2.right;
		}


		if (!Input.GetButton ("Fire2") && attack_iclicker && iclicker.activeSelf)
		{
			attack_iclicker = false;
		}

		if (gc.score == 0) 
		{
			die = true;
		}

		if (transform.position.y <= -25f) {
			die = true;
		}

		animator.SetBool ("Die", die);
		animator.SetBool ("AttackTool", attack_tool);
		animator.SetBool ("Die", die);
		animator.SetBool ("AttackIclicker", attack_iclicker);
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
			

		if (die) 
		{
			move = Vector2.zero;
			velocity = Vector2.zero;
		}
				
		/*
		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0f) : (move.x < 0f));
		if (flipSprite) {
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}*/

		animator.SetBool ("grounded", grounded);
		animator.SetBool ("jump", jump);
		animator.SetFloat ("speed", velocity.x);

		targetedVelocity = move * maxSpeed;
		targetedVelocity.x *= Xmultiplier;
	}
	
	/*
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.velocity = movement * speed;
	}
	*/




}
