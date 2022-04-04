using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// # Script that rotates literally an hexagon
public class RotatorScript : MonoBehaviour
{

	// The value of its rotation
	float RotationZ;

	// The speed it rotates
	float rotationSpeed = 6f;

	// !clockwise = L | clockwise = R;
	bool clockWise = true;

	// # Update is called once per frame
	void Update()
	{
		// This makes it go left
		if (!clockWise) {
			RotationZ += Time.deltaTime * rotationSpeed;
		}

		// And this is right (the direction)
		else {
			RotationZ += -Time.deltaTime * rotationSpeed;
		}
		
		// And this rotates the object with some math i don't understand 
		gameObject.transform.rotation = Quaternion.Euler(0, 0, RotationZ);
	}

} // END OF MAIN