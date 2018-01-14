using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	public float gravityModifier = 1f;
	public float minGroundNormaly = 0.65f;

	protected Vector2 targetedVelocity;
	protected Rigidbody2D rb2d;
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);
	protected bool grounded;
	protected Vector2 groundNormal;

	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	protected GameController gc;
	private int enemyHitDamage = 1;
	public bool can_hit = true;

	//private float next_hit = 0f;
	//private float hit_rate = 5f;


	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}


	// Use this for initialization
	void Start () {
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
		contactFilter.useLayerMask = true;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<GameController> ();
	}

	// Update is called once per frame
	void Update () {
		targetedVelocity = Vector2.zero;
		ComputeVelocity ();
		GetOtherInput ();

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!gameObject.CompareTag("Tool") && !gameObject.CompareTag("Feet") && other.gameObject.CompareTag("Enemy") &&  can_hit) //&& Time.time >= next_hit )
		{
			//next_hit += hit_rate;
			can_hit = false;
			gc.SetHitPoint (-enemyHitDamage);
			gc.UpdateHit ();
			gc.AddScore ();
			gc.UpdateScore ();
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(!gameObject.CompareTag("Tool") && !gameObject.CompareTag("Feet") && other.gameObject.CompareTag("Enemy") &&  !can_hit) 
		{
			can_hit = true;
		}
	}


	protected virtual void ComputeVelocity ()
	{
	}

	protected virtual void GetOtherInput ()
	{
	}

	void FixedUpdate()
	{
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		velocity.x = targetedVelocity.x;

		grounded = false;

		Vector2 deltaPosition = velocity * Time.deltaTime;

		Vector2 moveAloneGround = new Vector2 (groundNormal.y, -groundNormal.x);

		Vector2 move = moveAloneGround * deltaPosition.x;
		Movement (move, false);

		move = Vector2.up * deltaPosition.y;
		Movement (move, true);

	}

	void Movement (Vector2 move, bool yMovement)
	{
		float distance = move.magnitude;

		if (distance > minMoveDistance) {
			int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
			hitBufferList.Clear ();
			for (int i = 0; i < count; i++) {
				hitBufferList.Add (hitBuffer [i]);
			}

			for (int i = 0; i < hitBufferList.Count; i++) {
				Vector2 currentNormal = hitBufferList[i].normal;

				if (currentNormal.y > minGroundNormaly) {
					grounded = true;
					if (yMovement) {
						groundNormal = currentNormal;
						currentNormal.x = 0f;
					}
				}

				float projection = Vector2.Dot (velocity, currentNormal);
				if (projection < 0) {
					velocity = velocity - projection * currentNormal;
				}

				float modifiedDistance = hitBufferList [i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}

		}

		rb2d.position = rb2d.position + move.normalized * distance;
	}

}
