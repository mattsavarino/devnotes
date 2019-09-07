// last updated November 2016

﻿using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

	private Camera head;

	void Start () {
		head = GetComponentInChildren<Camera>();
	}

	void Update () {
		float rotationSpeed = 3.0f;
		float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
		float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

		// rotate player left/right
		transform.localRotation *= Quaternion.Euler(0, mouseX, 0);

		// rotate head up/down
		head.transform.localRotation *= Quaternion.Euler(-mouseY, 0, 0);
	}
}
