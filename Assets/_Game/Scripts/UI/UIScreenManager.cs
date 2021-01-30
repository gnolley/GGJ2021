using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenManager : MonoBehaviour
{
	[SerializeField] private RectTransform listScreen, emailScreen;
	[SerializeField] private float animTime = 0.15f, growScaleStart = 0.8f;

	public enum UIScreens { ListScreen, EmailScreen }
	UIScreens currentScreen;

	float ScreenWidth => listScreen.rect.width;

	/// <summary>
	/// Set starting conditions of the UI
	/// </summary>
	private void Start() {
		listScreen.gameObject.SetActive(true);
		emailScreen.gameObject.SetActive(false);
	}

	public void GoToScreen(UIScreens screen) {
		switch (screen) {
			case UIScreens.ListScreen:
				StopCoroutine(nameof(ToFirstScreen));
				StopCoroutine(nameof(ToSecondScreen));
				StartCoroutine(nameof(ToFirstScreen));
				break;
			case UIScreens.EmailScreen:
				StopCoroutine(nameof(ToFirstScreen));
				StopCoroutine(nameof(ToSecondScreen));
				StartCoroutine(nameof(ToSecondScreen));
				break;
		}
	}

	private IEnumerator ToSecondScreen() {
		listScreen.gameObject.SetActive(true);
		emailScreen.gameObject.SetActive(true);

		float t = 0;
		while (t < animTime) {
			Ease(t / animTime);
			t += Time.deltaTime;
			yield return null;
		}
		Ease(1);
		listScreen.gameObject.SetActive(false);
	}

	private IEnumerator ToFirstScreen() {
		listScreen.gameObject.SetActive(true);
		emailScreen.gameObject.SetActive(true);

		float t = 0;
		while (t < animTime) {
			Ease(1 - (t / animTime));
			t += Time.deltaTime;
			yield return null;
		}
		Ease(0);
		emailScreen.gameObject.SetActive(false);
	}

	private void Ease(float t) {
		listScreen.anchoredPosition = new Vector2(Mathf.Lerp(0, -ScreenWidth, acron0.Easings.QuadraticEaseInOut(t)),
			listScreen.anchoredPosition.y);
		emailScreen.localScale = Vector3.one * Mathf.Lerp(growScaleStart, 1f, acron0.Easings.QuadraticEaseInOut(t));
	}


}
