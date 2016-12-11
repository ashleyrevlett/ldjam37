using UnityEngine;
using System.Collections;

public class ThrowBalloon : MonoBehaviour {

	public bool canThrow = true; // can be set by levelcontroller
	public GameObject ammoObject;
	public Transform ammoOrigin;
	private bool isThrowing = false;
	private GameData gameData;


	void Start() {
		gameData = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameData> ();
	}

	void Update () {
		if (Input.GetKeyDown("space") && gameData.getAmmo() > 0 && canThrow) {
			StartCoroutine("throwAmmo");
		}
	}


	private IEnumerator throwAmmo() {

		isThrowing = true;

		gameData.changeAmmo (-1);

		Instantiate(ammoObject, new Vector3(ammoOrigin.position.x, ammoOrigin.position.y, 0), Quaternion.identity);
	
		yield return null;

		isThrowing = false;
	
	}
}
