// last updated November 2016

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdditiveScene : MonoBehaviour {

	// Private Variables
	private string mainScene = "_Main";

	// Public Variables
	public static AdditiveScene control;
	public string firstScene = "Scene1";

	// MonoBehavior Awake
	void Awake() {
		control = this;
	}

	// Use this for initialization
	void Start() {
		StartCoroutine( LoadLevel(firstScene) );
	}

	// LOAD LEVEL (called via the LevelLoader scripts too)
	public IEnumerator LoadLevel(string sceneName) {
		// Whatever is processed in the current frame needs to finish before loading new level
		yield return new WaitForEndOfFrame ();

		// Bug - Avoid reloading current additive scene
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		StartCoroutine( UnloadLevels(sceneName) );
		// Debug.Log("Loaded Scene: " + sceneName);
	}

	// UNLOAD LEVELS
	public IEnumerator UnloadLevels(string exception){
		// Whatever is processed in the current frame needs to finish before unloading
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < SceneManager.sceneCount; i++) {
			string sceneNameToUnload = SceneManager.GetSceneAt(i).name;
			if (sceneNameToUnload != exception && sceneNameToUnload != mainScene) {
				SceneManager.UnloadScene( sceneNameToUnload );
				// Debug.Log("Unloaded Scene: " + sceneNameToUnload);
			}
		}
	}
}
