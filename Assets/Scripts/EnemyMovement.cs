using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public bool canMove = true;
	public bool reverseMovement = false;
	public float moveSpeed = 40f;
	private float moveDir = 1f; // right hrz axis
	private Rigidbody2D body;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate (){
		body.velocity = new Vector2(moveDir * moveSpeed * Time.deltaTime, body.velocity.y);
	}

	public void stopMovement() {
		moveDir = 0f;
		moveSpeed = 0f;
	}
}
