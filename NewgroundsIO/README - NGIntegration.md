# Newgrounds.io X Unity

## INDEX
[-How to do that?](#how)

[-CODE STUFF](#code-stuff)

[-SNIPPETS AND CODE 2](#snippets-and-code-2)

[-Other stuff (still important)](#extra-stuff-still-important)

## How?

First of all, this is based off [bitbucket tutorial thingy of Newgrounds](https://bitbucket.org/newgrounds/newgrounds.io-for-unity-c/src/master/) so if you want to follow that one sure, both of these are basically the same

So, the steps are:

1. Create a Unity Project, it doesn't matter the version (i think)

2. Go to https://bitbucket.org/newgrounds/newgrounds.io-for-unity-c/downloads/ and download the .unitypackage file of the Newgrounds.io library

3. Import the file to the project, go to Assets > Import package > Custom package... and select the file

<img src = "https://media.discordapp.net/attachments/911301579938873406/960316491843112961/unknown.png">

4. Now to create a instance of the API onto the project do the next steps:

- Create an empty gameobject
- Click on "add new component"
- Search for 'Scripts' and then 'io.newgrounds' and click core

Your object should look like this 

<img src = "https://media.discordapp.net/attachments/911301579938873406/960317525730660362/unknown.png">

And then fill all of this boxes with the API keys that your newgrounds project has given you, if you're kinda confused, just search up 'how to create a newgrounds game projct' after creating one click on API Tools and search up these values' 

<img src = "https://media.discordapp.net/attachments/911301579938873406/960318956810403900/whreh.png">

DON'T SHARE THESE VALUES WITH ANYONE people can make their own apps with these and submit fake scores which will end up messing your game, even if many people don't know it just keep it private 

Session_id is the id of your sessions when your logged in the app, it fills out with the game, don't mind it 

5. Now, onto the code stuff.

### CODE STUFF

All the methods you need to do stuff are on the `NewgroundsMethods.cs` file, but to access to it i recommend etter using the `NewgroundsManager.cs` class so you can access the NGMethods AND the variables on the NGManager, to add references to this in your script do this:

To check these scripts by yourself go here:

> [NEWGROUNDS MANAGER](./Scripts/NewgroundsManager.cs) /
> [NEWGROUNDS METHODS](./Scripts/NewgroundsMethods.cs)

And the other script we will be working with
> [SCRIPTER](./Scripts/Scripter.cs)

- Make an empty gameObject (you can delete the transform if you want) and add the `NewgroundsManager.cs` and the `NewgroundsMethod.cs` scripts

- And then fill in the references of the scripts and objects
<img src = "https://media.discordapp.net/attachments/911301579938873406/960323638026981396/unknown.png">

- On the script you want to add newgrounds stuff to add a serialized NewgroundsManager and call it wharever you want
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourScript : MonoBehaviour
{
	// # Reference to the NewgroundsManager class
	// where i stored all the newgrounds stuff
	[SerializeField] NewgroundsManager NG;
	
} // END OF MAIN
```

- To assign the value of this class, go to the object you attached this script to, and search for the empty variable that says NewgroundsManager and drag the NG object to it

<img src = "https://media.discordapp.net/attachments/911301579938873406/960324163371950190/unknown.png">

### SNIPPETS AND CODE 2

Let's say you have a scripter script where you manage all the general behaviour of your game, and to implement the `NewgroundsManager.cs` you need a serialized reference to that class (which contains all the NG thingies) i'll use as example the script i showed you before, so your `Scripter.cs` should look like this:

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourScript : MonoBehaviour
{
	// # Reference to the NewgroundsManager class
	// where i stored all the newgrounds stuff
	[SerializeField] NewgroundsManager NG;
	
} // END OF MAIN
```
### HOW DO WE CHECK IF THE PLAYER IS LOGGED IN?
Using the built-in LoginCheck on the NGcore

```cs
public class NewgroundsManager : MonoBehaviour
{

	// # NGCORE THING very cool
	public io.newgrounds.core NGcore;

	[SerializeField] public NewgroundsMethods ngMethods;

	public bool IsLoggedIn;

	#region UnityEvents

	// # Start is called when the script gets called
	void Start()
	{		
		// # When the NGcore is ready
		NGcore.onReady(() => {
			// It uses the ChecksLogin() method
			ngMethods.ChecksLogin();
			Debug.Log("Logged is " + IsLoggedIn);
		});
	}
```

This method actually looks like this:

```cs
// ### NEWGROUNDSMETHODS.CS ###
// # Function that checks if the player is logged in using NGcore built-in checkLogin method
public void ChecksLogin() {
	ngManager.NGcore.checkLogin((bool logged_in) => {

		// If the parameter passed is true then we do the stuff
		// That happens when we're logged in
		if (logged_in) {
			OnLoggedIn();
		}

		// Else we request a login
		else {
			RequestLogin();
		}
	});
}
```

When we're logged in we set the IsLoggedIn variable to true in the OnLoggedIn method
```cs
// ### NEWGROUNDSMETHODS.CS ###
	// # Function that says what happens when you're logged in
	public void OnLoggedIn() {
		// Creates a new player instance and sets it to the current one 
		io.newgrounds.objects.user player = ngManager.NGcore.current_user;
		
		// Sets that the player is logged in
		ngManager.IsLoggedIn = true;
	}
```

### HOW TO UNLOCK MEDALS?
First, on our NewgroundsManager we should include a reference to the MEDALID we want to unlock (Check [Extra Stuff](#extra-stuff-still-important) for how to get this)
```cs
// ### NEWGROUNDSMANAGER.CS ###
public class NewgroundsManager : MonoBehaviour
{
	// # NGCORE
	public io.newgrounds.core NGcore;

	[SerializeField] public NewgroundsMethods ngMethods;

	// Bool to know if the player logged in or nah
	public bool IsLoggedIn;

	// I recommend you to give these values on the inspector, just in privacy cases 
	public int FiveScoreMedal;
	public int ScoreBoard_ID;

	public bool hasMedal;
}
```

```cs
// ### SCRIPTER.CS ###
public class Scripter : MonoBehaviour
{
	// # Reference to the NewgroundsManager class
	// where i stored all the newgrounds stuff
	[SerializeField] NewgroundsManager NG;

	int Score;

	// # Update gets called each frame 	
	void Update() {
		// Every time we press space we increment the score
		if (Input.GetKeyDown(KeyCode.Space)) {
			Score++;
		}

		// If the score is greater than 5 we access the bool to check if the medal was unlocked, if not, we unlock it with the UnlockMedal method passing as parameter the medal id
		if (Score > 5) {
			if (!NG.hasMedal) {
				NG.ngMethods.UnlockMedal(NG.FiveScoreMedal);
			}
		}
	}
} // END OF MAIN
```

### HOW DO I SUBMIT SCORES?
You need the SCOREBOARDID (Information on how to get it [here](#extra-stuff-still-important)) and pass it as parameter on the submit score method

My approach to this was to set a timer to submit these scores every 15-20 seconds, DON'T SUBMIT THEM ON UPDATE() it will be detected as DDOS and block your game from submitting scores, just don't

```cs
// ### NEWGROUNDS MANAGER
// # Script that manages all the newgrounds stuff
public class NewgroundsManager : MonoBehaviour
{
	// # NGCORE THING very cool
	public io.newgrounds.core NGcore;

	[SerializeField] public NewgroundsMethods ngMethods;
	[SerializeField] public Scripter Scripter;

	// I recommend you to give these values on the inspector, just in privacy cases 
	public int ScoreBoard_ID;

	float SubmitScoreTimer;

	// # Update is called every frame
	void Update()
	{
		// DO NOT MAKE API CALLS ON UPDATE it will be detected as DDOS and block your game from making them, which means
		// No medal unlocks or submitting scores

		SubmitScoreTimer += Time.deltaTime;

		// If the timer is greater than 30 it restarts and submits the scores
		if (SubmitScoreTimer >= 30.0f) {
			SubmitScoreTimer = 0;
			// The submitscore method takes as a parameter the 
			// scoreboard is uploading to and the value of the score, 
			// in this case the Score from the scripter class
			ngMethods.SubmitScore(ScoreBoard_ID, Scripter.Score);
		}
	}
} // END OF MAIN
```

And if you're curious, the SubmitScore method looks like this:
```cs
// ### NGMETHODS.CS ###
// # Method that submits the score taking the score_id from 
// newgrounds api tools and the actual score value
public void SubmitScore(int score_id, int score) {
	// Creates the posting score component
	io.newgrounds.components.ScoreBoard.postScore submit_score = new io.newgrounds.components.ScoreBoard.postScore();
	
	// Sets the ID to upload to the one in your project
	submit_score.id = score_id;
	
	// Sets the score to submit to the one you pass as a parameter 
	submit_score.value = score;
	
	// Calls the server with the core and makes these changes
	submit_score.callWith(ngManager.NGcore);
}
```
BTW you don't have to necessarily submit only scores, as the scoreboard says you can also upload times and other number thingies

### THAT SHOULD BE ALL!!
You should be now able to make api calls with the functions that i wrote, if you want to still check out the documentation you can find it here:

[- Newgrounds.IO DOCS -](http://www.newgrounds.io/help/)

## Extra stuff (still important)
To get Scoreboard IDS or MedalIDS go to your project api tools

**- For medals:**
Click on the big button below that says medal and fill up the stuff on it, name score secret etc and to get the ID is that one number below the name after you've saved the medal

<img src = "https://media.discordapp.net/attachments/911301579938873406/960329972986298448/unknown.png">

<br>

**- For scoreboard:**
Click on the big button below that says scoreboards, fill up the stuff on it, name type defaut etc and to get the id that number on the left of the name after you've saved the scoreboard

<img src = "https://media.discordapp.net/attachments/911301579938873406/960330199784894504/unknown.png?width=960&height=112"> 

### AND YEAH THAT'S ALL!! (again)
If you find any issues on this, somethign is missing or desinformative please let me know on an issue in this repo, thanks :)


