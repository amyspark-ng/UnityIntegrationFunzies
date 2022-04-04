using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// # Script that "controls" the whole behaviour of the game
public class Scripter : MonoBehaviour
{

	// # Reference to the NewgroundsManager class where i stored all the newgrounds stuff
	public NewgroundsManager NG;

	public int Score;
	TMP_Text scoreText;

	// # Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			Score++;
			scoreText.text = Score + "";
		}
	
		if (!NG.hasMedal) {
			if (Score > 5) {
				NG.ngMethods.UnlockMedal(NG.FiveScoreMedal);
			}
		}
	}
} // END OF MAIN
