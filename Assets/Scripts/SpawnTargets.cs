using UnityEngine;
using System.Collections;

public class SpawnTargets : MonoBehaviour {

	public Transform enemySpawnPoint; // where to spawn from
	public float spawnRate; // number per second
	public float spawnRateVariance; // max amount of randomness to add to spawn rate
	public GameObject[] enemyPrefabs; // things to spawn

	private bool canSpawn = true;
	private float timeElapsed = 0f;

	void Start() {
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
		Debug.Log ("Spawinign");
		GameObject enemy = enemyPrefabs [0];

		Instantiate(enemy, new Vector3(enemySpawnPoint.position.x, enemySpawnPoint.position.y, 0), Quaternion.identity);

		yield return null;

	}




}
