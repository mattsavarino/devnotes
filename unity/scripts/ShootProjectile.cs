// last updated November 2016

using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {

	public GameObject prefab;
	public GameObject origin;
	public float angle = 17.0f;
	public float speed = 12.0f;
	public float time = 2.0f;

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			shoot();
		}
	}

	void shoot() {
		GameObject p = Instantiate(prefab);
		p.transform.position = origin.transform.position;

		Rigidbody rb = p.GetComponent<Rigidbody>();
		Camera camera = GetComponentInChildren<Camera>();

		Quaternion shotAngle = Quaternion.AngleAxis(angle, Vector3.right);
		rb.velocity = shotAngle * camera.transform.forward * speed;

		Destroy(p, time);
	}

}
