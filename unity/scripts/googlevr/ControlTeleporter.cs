// last updated December 2016

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTeleporter : MonoBehaviour {


	public GameObject player;
	public GameObject laser;

	public float timeToReachTarget = 0.025f;

	public float initialVelocity = 8.0f;
	public float timeResolution = 0.02f;
	public float maxTime = 2.0f;

	public LayerMask layerMask = -1;
	public LayerMask layerHit = -1;

	private LineRenderer lineRenderer;
	private Vector3 endPos;
	private bool validDest;
	private bool isTeleporting = false;

	public Color colorValid = Color.green;
	public Color colorInvalid = Color.red;

	// Use this for initialization
	void Start () {
		lineRenderer = laser.GetComponent<LineRenderer>();
	}


	// Update is called once per frame
	void Update () {

		resetLaser();

		if (isTeleporting) {
			teleportPlayer();
		}
		else {
			handleControls();
		}
	}

	//
	// Handle Controller
	//
	void handleControls() {
		if (GvrController.AppButton) shootLaser();
		if (GvrController.AppButtonUp && validDest) isTeleporting = true;
	}

	//
	// Reset Laser
	//
	void resetLaser() {
		lineRenderer.SetVertexCount(1);
		colorLaser(colorInvalid);
	}

	//
	// Color Laser
	//
	void colorLaser(Color c) {
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c, 0.0f), new GradientColorKey(c, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;
	}

	//
	// Shoot Laser
	//
	void shootLaser() {

		// Reset validity when shooting laser
		validDest = false;

		// Set number of positions & add 1 to avoid out of bounds
		int pointsIndex = (int)(maxTime/timeResolution) + 1;
		lineRenderer.SetVertexCount( pointsIndex );

		int index = 0;
		Vector3 currentPostion = laser.transform.position;
		Vector3 velocityVector = laser.transform.forward * initialVelocity;

		for (float t = 0.0f; t < maxTime; t += timeResolution) {

			// Set postion using index
			lineRenderer.SetPosition(index, currentPostion);

			// Raycast
			RaycastHit hit;
			bool collision = Physics.Raycast(
				currentPostion,
				velocityVector,
				out hit,
				velocityVector.magnitude * timeResolution,
				layerMask
			);

			if (collision) {
				lineRenderer.SetVertexCount(index+2);
				lineRenderer.SetPosition(index+1,hit.point);

				Debug.Log("HIT: " + hit.transform.gameObject.name + " on Layer #" + hit.transform.gameObject.layer);

				// if (hit.transform.gameObject.layer == 8) {
				if ( layerHit.containsLayer(hit.transform.gameObject.layer) ) {
					validDest = true;
					endPos = hit.point;
					colorLaser(colorValid);
				}
				else {
					colorLaser(colorInvalid);
				}
				break;
			}

			currentPostion += velocityVector * timeResolution;
			velocityVector += Physics.gravity * timeResolution;

			index++;
		}
	}

	//
	// Teleport Player
	//
	void teleportPlayer() {
		float t = Time.deltaTime/timeToReachTarget;
		player.transform.position = Vector3.Lerp(player.transform.position, endPos, t);

		if (player.transform.position == endPos) {
			isTeleporting = false;
		}
	}
}
