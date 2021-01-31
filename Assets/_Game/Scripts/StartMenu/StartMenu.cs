using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// </summary>
public class StartMenu : MonoBehaviour {

	[SerializeField, Scene] private string gameScene;

	public void OnPlayButton() {
		SceneManager.LoadScene(gameScene);
	}

}