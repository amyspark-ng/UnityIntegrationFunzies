using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewgroundsMethods : MonoBehaviour
{

	[SerializeField] NewgroundsManager ngManager;

	#region LoginFunctions

	// # Function that checks if the player is logged in using NGcore built-in checkLogin method
	public void ChecksLogin() {
		ngManager.NGcore.checkLogin((bool logged_in) => {

			if (logged_in) {
				OnLoggedIn();
			}

			else {
				RequestLogin();
			}
			
			// If you press escape it ends your session
			// if (Input.GetKeyDown(KeyCode.Escape)) {
			// 	Debug.Log("Ended session");
			// 	ngManager.NGcore.logOut();
			// 	ngManager.IsLoggedIn = false;
			// }
		});
	}

	// # Function that says what happens when you're logged in
	public void OnLoggedIn() {
		// Creates a new player instance and sets it to the current one 
		io.newgrounds.objects.user player = ngManager.NGcore.current_user;
		
		// Sets that the player is logged in
		ngManager.IsLoggedIn = true;
	}

	// # Requests login using newgrounds passport 
	public void RequestLogin() {
		/* Parameters;
		1: The function that gets called when there's a new session ID
		2: The function that calls when it fails on create a new session ID
		3: The function that calls when the user cancels the login
		*/

		ngManager.NGcore.requestLogin(OnLoggedIn, OnLoginFailed, OnLoginCancelled);
	}

	// # Function that says what happens when login fails
	public void OnLoginFailed() {
		io.newgrounds.objects.error error = ngManager.NGcore.login_error;
	}

	// # Function that says what happens when login gets cancelled
	void OnLoginCancelled() {
		Debug.Log("Login got cancelled");
	}

	#endregion 

	#region MedalFunctions 

	/*
	# Method that unlocks medal taking the medal id as a parameter
	When using this i recommend storing each medal_id in a int var so you know which one is which one	
	*/
	public void UnlockMedal(int medalID) {
		// Creates the unlock component
		io.newgrounds.components.Medal.unlock medalUnlock = new io.newgrounds.components.Medal.unlock();

		// Sets the medalUnlock.id to the one you want to unlock
		medalUnlock.id = medalID;
		
		// Unlocks the medal and calls to the core so these changes can be made
		medalUnlock.callWith(ngManager.NGcore);
		
		// And fires this when everything up it's done
		OnMedalUnlocked();
	}

	// # Function that checks what happens when you unlock a medal
	public void OnMedalUnlocked() {
		Debug.Log("MEDAL GOT UNLOCKED");
	}

	#endregion

	#region ScoreFunctions

	// # Method that submits the score taking the score_id from newgrounds developer tools and the actual score value
	public void SubmitScore(int score_id, int score) {
		// Creates the ScoreBoard.postScore component
		io.newgrounds.components.ScoreBoard.postScore submit_score = new io.newgrounds.components.ScoreBoard.postScore();
		
		// Sets the submitScoreID to the one in your project
		submit_score.id = score_id;
		
		// Sets the value to send to the server to the one in your game
		submit_score.value = score;
		
		// Calls the server with the core and makes these changes
		submit_score.callWith(ngManager.NGcore);
	}

	#endregion

} // END OF MAIN