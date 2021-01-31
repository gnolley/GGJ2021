using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField] private CanvasGroup canvasGroup;
	[SerializeField] private float fadeTime, gameOverFadeDelay = 3f;
	[SerializeField, Scene] private string reportCardScene;

	public void GameOver() {
		gameObject.SetActive(true);
		StopCoroutine(nameof(FadeIn));
		StartCoroutine(nameof(FadeIn));

		StopCoroutine(nameof(LoadReportCardScene));
		StartCoroutine(nameof(LoadReportCardScene));
	}

	IEnumerator LoadReportCardScene() {
		AsyncOperation asyncOp = SceneManager.LoadSceneAsync(reportCardScene);
		asyncOp.allowSceneActivation = false;

		yield return new WaitForSeconds(gameOverFadeDelay);
		asyncOp.allowSceneActivation = true;
	}

	private IEnumerator FadeIn() {
		float t = 0;
		while (t < fadeTime) {
			Fade(t / fadeTime);
			t += Time.deltaTime;
			yield return null;
		}
		Fade(1f);
	}

	private void Fade(float t) {
		canvasGroup.alpha = Mathf.Lerp(0, 1, acron0.Easings.QuadraticEaseIn(t));
	}
}
