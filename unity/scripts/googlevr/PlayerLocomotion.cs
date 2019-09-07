// last updated Febuary 2016

﻿using UnityEngine;
using System.Collections;

public class PlayerLocomotion : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update () {}

	public void TeleportPlayer() {
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		float distance = 2 * Random.value + 1.5f;
		player.transform.position = direction * distance;
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		// SetGazedAt(true);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
	// SetGazedAt(false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnPointerExit.
	public void OnGazeTrigger() {
	TeleportPlayer();

	/*
	GameObject targetObject,
	Vector3 intersectionPosition,
	Ray intersectionRay,
	bool isInteractive
	*/
	}

	#endregion
}
