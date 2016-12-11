using UnityEngine;
using System.Collections;

public class ScoreOnTrigger : MonoBehaviour {

	private AudioSource audio;
	private Animator anim;
	private bool isScoring = false;
	private GameData gameData;
	private EnemyMovement movement;

	void Start() {
		gameData = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameData> ();
		anim = gameObject.GetComponentInParent<Animator> ();
		movement = gameObject.GetComponentInParent<EnemyMovement>();
		audio = gameObject.GetComponent<AudioSource> ();
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

		anim.SetTrigger ("hit");

		audio.Play ();

		yield return new WaitForSeconds(2);

		Destroy(gameObject.transform.parent.gameObject);

	}


}
