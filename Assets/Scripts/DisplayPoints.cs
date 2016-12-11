using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPoints : MonoBehaviour {

	GameData gameData;
	Text theText;

	void Start() {
		theText = GetComponent<Text> ();
		gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData> ();
	}

	void Update () {
		theText.text = string.Format ("POINTS: {0}", gameData.getPoints());
	}
}
