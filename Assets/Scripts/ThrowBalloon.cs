using UnityEngine;
using System.Collections;

public class ThrowBalloon : MonoBehaviour {

	public bool canThrow = true;
	public GameObject ammoObject;
	public Transform ammoOrigin;

	private bool isThrowing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("f")) {
			StartCoroutine("spawnAmmo");
		}
	}

	private IEnumerator spawnAmmo() {
	
		isThrowing = true;

		Instantiate(ammoObject, new Vector3(ammoOrigin.position.x, ammoOrigin.position.y, 0), Quaternion.identity);
	
		yield return null;

		isThrowing = false;
	
	
	}
}
