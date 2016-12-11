using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public int startingTime = 30;
	private int timeRemaining;
	public Text timeText;

	void Start () {
		Stop ();
		timeRemaining = startingTime;
		StartCoroutine ("countdown");
	}
		
	public void Stop() {
		StopCoroutine ("countdown");
		timeText.text = string.Format ("{0}", timeRemaining);
	}
		
	private IEnumerator countdown() {
		while (timeRemaining > 0) {
			timeText.text = string.Format ("{0}", timeRemaining);
			timeRemaining -= 1;
			yield return new WaitForSeconds(1);
		}
		timeText.text = string.Format ("{0}", timeRemaining);
	}

	public int getTime() {
		return timeRemaining;
	}

}
