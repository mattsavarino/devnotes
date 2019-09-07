// last updated November 2016

﻿using UnityEngine;
using System.Collections;

public class ControllerOrientation : MonoBehaviour {
	void Update () {
		transform.localRotation = GvrController.Orientation;
	}
}
