﻿using UnityEngine;
using System.Collections;

public class ScoreOnTrigger : MonoBehaviour {
	
	private Animator anim;
	private bool isScoring = false;
	private GameData gameData;
	private EnemyMovement movement;

	void Start() {
		gameData = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameData> ();
//		anim = gameObject.GetComponentInParent<Animator> ();
//		body = gameObject.GetComponentInParent<Rigidbody2D> ();
		movement = gameObject.GetComponentInParent<EnemyMovement>();
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (!isScoring && other.tag == "Ammo") {
			isScoring = true;
			gameData.changePoints (1);
			StartCoroutine ("die");	
		}
	}

	private IEnumerator die() {

		movement.stopMovement ();

		yield return new WaitForSeconds(1);

		Destroy(gameObject.transform.parent.gameObject);

	}


}