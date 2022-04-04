# Newgrounds.io X Unity

## INDEX
[-How to do that?](#how)

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

All the methods you need to do stuff are on the `NewgroundsMethods.cs` file, but to access to it i recommend etter using the `NewgroundsManager` class so you can access the NGMethods AND the variables on the NGManager, to add references to this in your script do this:

To check these scripts by youeself go here:

- [NEWGROUNDS MANAGER](./NewgroudsTesting/Assets/Scripts/NewgroundsManager.cs)
- [NEWGROUNDS METHODS](./NewgroudsTesting/Assets/Scripts/NewgroundsMethods.cs)


- Make an empty gameObject (you can delete the transform if you want) and add the `NewgroundsManager` and the `NewgroundsMethod` scripts

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
