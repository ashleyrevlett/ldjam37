using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject levelEndPanel;
	GameData gameData;
	Countdown countdown;
	ThrowBalloon throwBalloon;
	SpawnTargets spawner;
	PlayerMovementController playermove;

	// Use this for initialization
	void Start () {

		Debug.Log ("LEvelController starting");
		countdown =  GetComponent<Countdown> ();
		gameData = GetComponent<GameData> ();
		spawner = GetComponent<SpawnTargets> ();

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		throwBalloon = player.GetComponent<ThrowBalloon> ();
		playermove = player.GetComponent<PlayerMovementController> ();

		levelEndPanel.SetActive (false);
	}

	void Awake() {
		Debug.Log ("LEvelController AWAKE");
	}
	// Update is called once per frame
	void Update () {
	
		if (gameData.getAmmo () <= 0 || countdown.getTime() <= 0) {
			EndLevel ();
		}

	}

	public void EndLevel() {
	
		// called from countdown ending or ammo ending

		StopAllCoroutines ();

		// pause timer
		countdown.Stop();

		// disable throwing and walking for player
		throwBalloon.canThrow = false;
		playermove.canMove = false;

		// enemy spawning
		spawner.StopSpawning();

		// walking for all enemies
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Target");
		for (int i = 0; i < enemies.Length; i++ ) {
			GameObject enemy = enemies [i];
			EnemyMovement movement = enemy.GetComponent<EnemyMovement> ();
			if (movement != null) 
				movement.pause ();
			
		}

		levelEndPanel.SetActive (true);
	}

	public void Restart() {

		Debug.Log ("LEvelController RESTART");

		Application.LoadLevel(Application.loadedLevel);

	}

}
