using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// # Script that manages all the newgrounds stuff
public class NewgroundsManager : MonoBehaviour
{

	// # NGCORE THING very cool
	public io.newgrounds.core NGcore;

	[SerializeField] public NewgroundsMethods ngMethods;
	[SerializeField] public Scripter scripter;

	// Reference to the Scripter script

	/*
	Some vars to count the time to check if the player is logged in
	And to know if the player is logged in or nah
	*/
	public bool IsLoggedIn;

	// I recommend you to give these values on the inspector, just in privacy cases 
	public int FiveScoreMedal;
	public int ScoreBoard_ID;

	public bool hasMedal;

	#region UnityEvents

	// # Start is called when the script gets called
	void Start()
	{		
		// # Checks when the NGcore is ready
		NGcore.onReady(() => {
			ngMethods.ChecksLogin();
			Debug.Log("Logged is " + IsLoggedIn);
		});
	}

	// # Update is called every frame
	void Update()
	{
		// DO NOT MAKE API CALLS ON UPDATE it will be detected as DDOS and block your game from making them, which means
		// No medal unlocks or submitting scores
	}

	#endregion

} // END OF MAIN
