using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public int startingTime = 30;
	private int timeRemaining;
	public Text timeText;

	void Start () {
		Reset();
	}

	void Reset() {
		StopCoroutine ("countdown");
		timeRemaining = startingTime;
		timeText.text = string.Format ("{0}", timeRemaining);
		StartCoroutine ("countdown");
	}

	private IEnumerator countdown() {

		while (timeRemaining > 0) {
			timeText.text = string.Format ("{0}", timeRemaining);
			timeRemaining -= 1;
			yield return new WaitForSeconds(1);
		}

		timeText.text = string.Format ("{0}", timeRemaining);

	}

}
