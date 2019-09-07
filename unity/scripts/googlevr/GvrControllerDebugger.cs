// last updated June 2016

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GvrControllerDebugger : MonoBehaviour {

	public GameObject mirroredObject;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Get controller's current orientation
		Quaternion ori = GvrController.Orientation;

		// If you want a vector that points in the direction of the controller
		// you can just multiply this quat by Vector3.forward:
		Vector3 vector = ori * Vector3.forward;

		// ...or you can just change the rotation of some entity on your scene
		// (e.g. the player's arm) to match the controller's orientation
		if (mirroredObject) {
			mirroredObject.transform.localRotation = ori;
		}

		//
		// TOUCH PAD
		//
		if (GvrController.IsTouching) {
			// True if user is currently touching the touchpad
			// TouchPos = position of the current touch, if touching. If not touching, then this is the position of the last touch (when the finger left the touchpad)
			Vector2 touchPos = GvrController.TouchPos;
			Debug.Log(Time.frameCount + " GvrController.TouchPos = " + touchPos);
		}

		if (GvrController.TouchDown) {
			// True for 1 frame after user starts touching the touchpad
			Debug.Log(Time.frameCount + " GvrController.TouchDown");
		}

		if (GvrController.TouchUp) {
			// True for 1 frame after user stops touching the touchpad
			Debug.Log(Time.frameCount + " GvrController.TouchUp");
		}

		//
		// CLICK BUTTON
		//
		if (GvrController.ClickButton) {
			// True if the Click button (a touchpad click) is currently being pressed.
			Debug.Log(Time.frameCount + " GvrController.ClickButton");
		}

		if (GvrController.ClickButtonDown) {
			// True for 1 frame after user starts pressing the Click button.
			Debug.Log(Time.frameCount + " GvrController.ClickButtonDown");
		}

		if (GvrController.ClickButtonUp) {
			// True for 1 frame after user stops pressing the Click button.
			Debug.Log(Time.frameCount + " GvrController.ClickButtonUp");
		}

		//
		// APP BUTTON
		//
		if (GvrController.AppButton) {
			// True if the App button is currently being pressed.
			Debug.Log(Time.frameCount + " GvrController.AppButton");
		}

		if (GvrController.AppButtonDown) {
			// True for 1 frame after user starts pressing the App button.
			Debug.Log(Time.frameCount + " GvrController.AppButtonDown");
		}

		if (GvrController.AppButtonUp) {
			// True for 1 frame after user stops pressing the App button.
			Debug.Log(Time.frameCount + " GvrController.AppButtonUp");
		}

	}
}
