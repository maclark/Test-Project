using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (CrossPlatformInputManager.GetButton("Vertical") && CrossPlatformInputManager.GetAxisRaw("Vertical") > 0) {
			print ("up");
		}
		else if (CrossPlatformInputManager.GetButton("Vertical") && CrossPlatformInputManager.GetAxisRaw("Vertical") < 0) {
			print ("down");
		}

		if (CrossPlatformInputManager.GetButton("Horizontal") && CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0) {
			print ("right");
		}
		else if (CrossPlatformInputManager.GetButton("Horizontal") && CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0) {
			print ("left");
		}
	}
}
