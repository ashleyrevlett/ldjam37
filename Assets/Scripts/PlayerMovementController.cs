﻿using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

	//Movement related variables
	public float moveSpeed;  //Our general move speed. This is effected by our
	//InputManager > Horizontal button's Gravity and Sensitivity
	//Changing the Gravity/Sensitivty will in turn result in more loose or tighter control

	//Jump related variables
	public float initialJumpForce;       //How much force to give to our initial jump
	private bool playerJumped;           //Tell us if the player has jumped
	private bool playerJumping;          //Tell us if the player is holding down the jump button
	public Transform groundChecker;      //Gameobject required, placed where you wish "ground" to be detected from
	private bool isGrounded;             //Check to see if we are grounded

	void Update () {
		//Casts a line between our ground checker gameobject and our player
		//If the floor is between us and the groundchecker, this makes "isGrounded" true
		isGrounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));

		//If our player hit the jump key, then it's true that we jumped!
		if (Input.GetButtonDown("Jump") && isGrounded){
			playerJumped = true;   //Our player jumped!
			playerJumping = true;  //Our player is jumping!
		}

		//If our player lets go of the Jump button OR if our jump was held down to the maximum amount...
		if (Input.GetButtonUp("Jump")){
			playerJumping = false; //... then set PlayerJumping to false
		}

	}

	void FixedUpdate (){
		
		//If we're not sprinting, then give us our general momentum
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,GetComponent<Rigidbody2D>().velocity.y);

		//If our player pressed the jump key...
		if (playerJumped){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,initialJumpForce)); //"Jump" our player up in the air!
			playerJumped = false; //Our player already jumped, so no need to jump again just yet
		}

	}
}
