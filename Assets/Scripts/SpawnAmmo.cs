using UnityEngine;
using System.Collections;

public class SpawnAmmo : MonoBehaviour {

	public float spawnRate; // number per second
	public GameObject ammo; // things to spawn

	private Transform spawnPoint; // where to spawn from
	private bool canSpawn = true;
	private float timeElapsed = 0f;

	void Start() {
		spawnPoint = gameObject.transform;
		StartCoroutine ("spawn");
	}

	public void StopSpawning() {
		canSpawn = false;
	}

	void Update () {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > spawnRate && canSpawn) {
			timeElapsed = 0;
			StartCoroutine ("spawn");
		}
	}


	private IEnumerator spawn() {
		Instantiate(ammo, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0), Quaternion.identity);

		yield return null;

	}
}
