// last updated November 2016

﻿using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXandY;

	public float sensitvityHor = 9.0f;
	public float sensitvityVert = 9.0f;

	public float minVert = -45.0f;
	public float maxVert = 45.0f;

	public float _rotationX = 0;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null) {
			body.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitvityHor, 0);
		}
		else {
			_rotationX = Input.GetAxis ("Mouse Y") * sensitvityVert;
			_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);

			float rotationY;
			if (axes == RotationAxes.MouseY) {
				rotationY = transform.localEulerAngles.y;
			}
			else {
				float delta = Input.GetAxis ("Mouse X") * sensitvityHor;
				rotationY = transform.localEulerAngles.y + delta;
			}

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
	}
}
