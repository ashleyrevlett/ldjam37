using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameData : MonoBehaviour {

	private int points = 0;
	private int ammo = 10;
	public Text pointsText;
	public Text ammoText;

	void Start () {
		refreshDisplay();
	}

	void refreshDisplay() {
		pointsText.text = string.Format ("{0} POINTS", points);
		ammoText.text = string.Format ("{0} BALLOONS", ammo);
	}

	public void changePoints(int change) {
		points += change;
		points = Mathf.Max (0, points);
		refreshDisplay ();
	}

	public void changeAmmo(int change) {
		ammo += change;
		ammo = Mathf.Max (0, ammo);
		refreshDisplay ();
	}

	public int getAmmo() {
		return ammo;
	}


}

