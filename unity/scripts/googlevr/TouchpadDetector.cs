// last updated June 2016

﻿using UnityEngine;
using System.Collections;

public class TouchpadDetector : MonoBehaviour {

	private readonly Vector2 maxXAxis = new Vector2(1, 0);
	private readonly Vector2 maxYAxis = new Vector2(0, 1);

	// The angle range for detecting swipe
	private const float minAngle = 35;

	// To recognize as swipe user should at lease swipe for this many pixels
	private const float minDistance = 0.1f;

	// To recognize as a swipe the velocity of the swipe should be at least minVelocity
	// Reduce or increase to control the swipe speed
	private const float minVelocity  = 2.0f;

	private Vector2 posStart;
	private Vector2 posLast;
	private Vector2 posEnd;
	private float timeStart;

	void DebugLog(string msg) {
		Debug.Log(msg);
	}

	private int frame = 0; // global frame count

	// Update is called once per frame
	void Update () {
		frame++;

		if (GvrController.TouchDown) {
			// DebugLog("F" + frame + " TouchDown at " + GvrController.TouchPos);
			posStart = GvrController.TouchPos;
			timeStart = Time.time;
		}
		else if (GvrController.IsTouching) {
			// DebugLog("F" + frame + " IsTouching at " + GvrController.TouchPos);
			posLast = GvrController.TouchPos;
		}
		else if (GvrController.TouchUp) {
			// DebugLog("F" + frame + " TouchUp at " + GvrController.TouchPos);
			posEnd = GvrController.TouchPos;

			DebugLog("posStart = " + posStart);
			DebugLog("posLast = " + posLast);
			DebugLog("posEnd = " + posEnd);

			float deltaTime = Time.time - timeStart;
			Vector2 swipeVector = posEnd - posStart;
			float velocity = swipeVector.magnitude / deltaTime;

			DebugLog("deltaTime = " + deltaTime);
			DebugLog("swipeVector = " + swipeVector);
			DebugLog("swipeVector.magnitude = " + swipeVector.magnitude);
			DebugLog("velocity = " + velocity);

			if (!(velocity > minVelocity)) {
				DebugLog("NO minimum velocity :(");
			}

			if (!(swipeVector.magnitude > minDistance)) {
				DebugLog("NO minimum magnitude :(");
			}

			if (velocity > minVelocity && swipeVector.magnitude > minDistance) {

				swipeVector.Normalize();
				float angleOfSwipe = Vector2.Dot(swipeVector, maxXAxis);
				angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

				DebugLog("angleOfSwipe = " + angleOfSwipe);

				// Detect left and right swipe
				if (angleOfSwipe < minAngle) {
					// OnSwipeRight();
					DebugLog("Swipe Right!");
				} else if ((180.0f - angleOfSwipe) < minAngle) {
					// OnSwipeLeft();
					DebugLog("Swipe Left!");
				}
				else {
					// Detect top and bottom swipe
					angleOfSwipe = Vector2.Dot(swipeVector, maxYAxis);
					angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
					if (angleOfSwipe < minAngle) {
						// OnSwipeTop();
						DebugLog("Swipe Top!");
					} else if ((180.0f - angleOfSwipe) < minAngle) {
						// OnSwipeBottom();
						DebugLog("Swipe Bottom!");
					} else {
						DebugLog("Swipe Huh?");
					}
				}


			}

		}
	}
}
