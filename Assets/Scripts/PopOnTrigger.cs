using UnityEngine;
using System.Collections;

public class PopOnTrigger : MonoBehaviour {


	private AudioSource audio;
	private Animator anim;
	private Rigidbody2D body;
	private bool hasPopped = false;
	private bool isPopping = false;
	private GameData gameData;

	void Start () {
		anim = gameObject.GetComponentInParent<Animator> ();
		body = gameObject.GetComponentInParent<Rigidbody2D> ();
		audio = gameObject.GetComponent<AudioSource> ();
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Triggered entered");
		if (!isPopping && other.tag != "Ammo") {
			StartCoroutine ("pop");	
		}
	}
		
	private IEnumerator pop() {
		isPopping = true;
		body.velocity = Vector2.zero;
		body.angularVelocity = 0f;
		body.gravityScale = 0f;
		anim.SetTrigger ("pop");

		audio.Play ();

		yield return new WaitForSeconds(1);

		Destroy(gameObject.transform.parent.gameObject);

	}

}
