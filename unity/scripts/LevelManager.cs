// last updated November 2016

﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start () {}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			LoadScene("MAIN_SCENE_NAME");
		}
	}

	public void LoadNextScene() {
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex + 1);
	}

	public void LoadPrevScene() {
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex - 1);
	}

	public void LoadScene(string name) {
		SceneManager.LoadScene(name);
	}

}
