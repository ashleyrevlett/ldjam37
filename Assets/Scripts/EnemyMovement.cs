using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public bool canMove = true;
	public bool reverseMovement = false;
	public float minMoveSpeed = 30f;
	public float maxMoveSpeed = 60f;

	private float moveSpeed;
	private float moveDir = 1f; // right hrz axis
	private Rigidbody2D body;
	private Animator anim;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
	}

	void FixedUpdate (){
		body.velocity = new Vector2(moveDir * moveSpeed * Time.deltaTime, body.velocity.y);
	}

	public void stopMovement() {
		moveDir = 0f;
		moveSpeed = 0f;
	}

	public void pause() {
		stopMovement ();
		anim.enabled = false;
	}
}
